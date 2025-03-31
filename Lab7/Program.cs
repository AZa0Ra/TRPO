using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7
{
    internal class Program
    {
        static ManualResetEvent findNegativeDone = new ManualResetEvent(false);
        static ManualResetEvent sumNegativeDone = new ManualResetEvent(false);
        //static Mutex mutex = new Mutex();

        static void Main(string[] args)
        {
            int[,] matrix = {
            { 1, 2, 2, 3 },
            { 4, 4, 4, -5 },
            { 6, 7, -7, 8 },
            { 9, 9, 1, 1 }
        };

            Console.OutputEncoding = Encoding.UTF8;
            Print(matrix);

            Thread findNegativethread = new Thread(() => FindNegative(matrix));
            findNegativethread.Start();

            Thread sumNegativeDone = new Thread(() => SumNegative(matrix));
            sumNegativeDone.Start();

            Thread sortThread = new Thread(() => SortRowsByDuplicateCount(matrix));
            sortThread.Start();

            findNegativethread.Join();
            sumNegativeDone.Join();
            sortThread.Join();
        }

        static void FindNegative(int[,] matrix)
        {
            //mutex.WaitOne();
            Console.WriteLine("\nПошук стовпця з від'ємним елементом..");
            Thread.Sleep(1000);
            int index = -1;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        index = i;
                        break;
                    }
                }

            }
            Console.WriteLine($"Номер першого із стовпців, який не містить ні одного від’ємного елемента: {index}");
            //mutex.ReleaseMutex();
            findNegativeDone.Set();
        }

        static void SumNegative(int[,] matrix)
        {
            //mutex.WaitOne();
            findNegativeDone.WaitOne();
            Console.WriteLine("\nПідрахунок суми кожного рядка..");
            Thread.Sleep(3000);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                bool hasNegative = false;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }

                if (hasNegative)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        sum += matrix[i, j];
                    }
                    Console.WriteLine($"Сума рядка {i + 1}, який має хоча б 1 мінус: {sum}");
                }
            }

            sumNegativeDone.Set();
        }

        static void SortRowsByDuplicateCount(int[,] matrix)
        {
            sumNegativeDone.WaitOne();
            Console.WriteLine("\nСортування рядків.. ");
            Thread.Sleep(3000);

            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            int[] duplicateCounts = new int[rowCount];

            for (int i = 0; i < rowCount; i++)
            {
                int[] row = new int[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    row[j] = matrix[i, j];
                }
                duplicateCounts[i] = row.Length - row.Distinct().Count(); 
            }

            for (int i = 0; i < rowCount - 1; i++)
            {
                for (int j = i + 1; j < rowCount; j++)
                {
                    if (duplicateCounts[i] > duplicateCounts[j])
                    {
                        for (int k = 0; k < colCount; k++)
                        {
                            int temp = matrix[i, k];
                            matrix[i, k] = matrix[j, k];
                            matrix[j, k] = temp;
                        }
                        int tempCount = duplicateCounts[i];
                        duplicateCounts[i] = duplicateCounts[j];
                        duplicateCounts[j] = tempCount;
                    }
                }
            }

            Console.WriteLine("Матриця після сортування:");
            Print(matrix);
            //mutex.ReleaseMutex();
        }
        static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }


}
