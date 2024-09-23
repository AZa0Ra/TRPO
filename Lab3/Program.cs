using System;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> intMatrix = new Matrix<int>(3, 3);
            intMatrix.Fill(0);
            intMatrix[0, 1] = 5;
            intMatrix[2, 2] = 5;

            Console.WriteLine("Matrix value type:");
            Console.WriteLine(intMatrix.ToString());
            Console.WriteLine($"Count of columns with at least one zero number: {intMatrix.CountColumnsWithZero()}");
            Console.WriteLine($"Row with max count of equal elements: {intMatrix.RowWithMostEqualElements()}");

            Matrix<string> stringMatrix = new Matrix<string>(3, 3);
            stringMatrix.Fill("hello");
            stringMatrix[1, 2] = "world";

            Console.WriteLine("\nMatrix reference type:");
            Console.WriteLine(stringMatrix.ToString());
            Console.WriteLine($"Count of columns with at least one zero number: {stringMatrix.CountColumnsWithZero()}");
            Console.WriteLine($"Row with max count of equal elements: {stringMatrix.RowWithMostEqualElements()}");

        }
    }
}
