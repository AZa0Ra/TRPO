using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    internal class Program
    {
        static double[,] simplexTable;
        static int rowCount;
        static int colCount;
        static int pivotRow;
        static int pivotCol;
        static int threadCount = Environment.ProcessorCount;

        static void Main()
        {
            InitializeSimplexTable(); 

            Console.WriteLine("Ініціалізація симплекс методу:");
            PrintTable();


            pivotCol = 1; 
            pivotRow = 1; 

            ParallelUpdateSimplexTable();

            Console.WriteLine("Опрацювання симплекс методу:");
            PrintTable();
        }

        static void InitializeSimplexTable()
        {
            // 4 обмеження → 4 додаткові змінні → 6 змінних (x1, x2, s1, s2, s3, s4)
            // Формуємо таблицю: [F | x1 x2 s1 s2 s3 s4 | RHS]
            simplexTable = new double[,]
            {
            { 1, -5, -1,  0,  0,  0,  0,   0 },   // F(x) = -5x1 - x2 (бо max → min)
            { 0,  1, -3,  1,  0,  0,  0,   1 },   // x1 - 3x2 ≤ 1
            { 0, -1, -1,  0,  1,  0,  0,  -5 },   // -x1 - x2 ≤ -5 (x1 + x2 ≥ 5)
            { 0,  0,  1,  0,  0,  1,  0,   8 },   // x2 ≤ 8
            { 0,  2,  1,  0,  0,  0,  1,  16 },   // 2x1 + x2 ≤ 16
            };

            rowCount = simplexTable.GetLength(0);
            colCount = simplexTable.GetLength(1);
        }

        static void ParallelUpdateSimplexTable()
        {
            double pivotElement = simplexTable[pivotRow, pivotCol];

            for (int j = 0; j < colCount; j++)
            {
                simplexTable[pivotRow, j] /= pivotElement;
            }

            Barrier barrier = new Barrier(threadCount);

            Task[] tasks = new Task[threadCount];

            for (int t = 0; t < threadCount; t++)
            {
                int threadIndex = t;
                tasks[t] = Task.Run(() =>
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (i == pivotRow) continue;
                        if (i % threadCount != threadIndex) continue;

                        double factor = simplexTable[i, pivotCol];
                        for (int j = 0; j < colCount; j++)
                        {
                            simplexTable[i, j] -= factor * simplexTable[pivotRow, j];
                        }
                    }

                    barrier.SignalAndWait(); 
                });
            }

            Task.WaitAll(tasks);
        }

        static void PrintTable()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write($"{simplexTable[i, j],8:F2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}