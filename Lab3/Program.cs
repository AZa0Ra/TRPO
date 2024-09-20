using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Створення матриці типу int розміром 3x3
            Matrix<int> intMatrix = new Matrix<int>(3, 3);

            // Заповнення матриці значенням 5
            intMatrix.Fill(5);

            // Виведення матриці
            intMatrix.Print();

            // Встановлення конкретного елементу
            intMatrix[1, 1] = 10;
            Console.WriteLine();

            // Виведення після зміни елементу
            intMatrix.Print();
        }
    }



    public class Matrix<T> where T : IComparable<T>
    {
        private T[,] data;

        // Конструктор для створення матриці заданого розміру
        public Matrix(int rows, int columns)
        {
            data = new T[rows, columns];
        }

        // Індексатор для доступу до елементів матриці
        public T this[int row, int column]
        {
            get => data[row, column];
            set => data[row, column] = value;
        }

        // Метод для заповнення матриці значеннями
        public void Fill(T value)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = value;
                }
            }
        }

        // Метод для виведення матриці
        public void Print()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write($"{data[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        // Метод для отримання кількості рядків
        public int Rows => data.GetLength(0);

        // Метод для отримання кількості стовпців
        public int Columns => data.GetLength(1);

        public void InitializeReferenceTypes()
        {
            if (typeof(T).IsClass) // Перевіряємо, чи є T типом-посиланням
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        data[i, j] = Activator.CreateInstance<T>(); // Створюємо екземпляри типу-посилання
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Цей метод може використовуватися тільки для типів-посилань.");
            }
        }

        // Метод для роботи тільки з типами-значеннями
        public void InitializeValueTypes(T defaultValue) 
        {
            if (typeof(T).IsValueType) // Перевіряємо, чи є T типом-значенням
            {
                Fill(defaultValue); // Заповнюємо матрицю значенням за замовчуванням
            }
            else
            {
                throw new InvalidOperationException("Цей метод може використовуватися тільки для типів-значень.");
            }
        }
    }

}
