using System.Diagnostics;
using System.Text;

namespace Module4
{
    internal class Program
    {
        static int[] data;
        static int[] dataParallel;
        static int chunkCount = 4;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int size = 6000; 
            data = GenerateRandomArray(size);
            dataParallel = (int[])data.Clone();

            Console.WriteLine("Сортування Shell:");

            // Послідовне сортування 6000
            var sw1 = Stopwatch.StartNew();
            ShellSort(data);
            sw1.Stop();
            Console.WriteLine($"Час послідовного сортування: {sw1.Elapsed.TotalMilliseconds:F10} мс ({size} елементів)");

            // Паралельне сортування 6000
            var sw2 = Stopwatch.StartNew();
            ParallelShellSort(dataParallel, chunkCount);
            sw2.Stop();
            Console.WriteLine($"Час паралельного сортування: {sw2.Elapsed.TotalMilliseconds:F10} мс ({size} елементів)");

            Console.WriteLine();
            size = 60000;
            data = GenerateRandomArray(size);
            dataParallel = (int[])data.Clone()
                ;
            // Послідовне сортування 60000
            sw1 = Stopwatch.StartNew();
            ShellSort(data);
            sw1.Stop();
            Console.WriteLine($"Час послідовного сортування: {sw1.Elapsed.TotalMilliseconds:F10} мс ({size} елементів)");

            // Паралельне сортування 60000
            sw2 = Stopwatch.StartNew();
            ParallelShellSort(dataParallel, chunkCount);
            sw2.Stop();
            Console.WriteLine($"Час паралельного сортування: {sw2.Elapsed.TotalMilliseconds:F10} мс ({size} елементів)");
        }

        static void ShellSort(int[] array)
        {
            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
        }

        static void ParallelShellSort(int[] array, int threadCount)
        {
            int n = array.Length;
            int chunkSize = n / threadCount;
            Thread[] threads = new Thread[threadCount];
            for (int t = 0; t < threadCount; t++)
            {
                int start = t * chunkSize;
                int end = (t == threadCount - 1) ? n : start + chunkSize;

                threads[t] = new Thread(() => ShellSortRange(array, start, end));
                threads[t].Start();
            }

            foreach (var thread in threads)
                thread.Join();
            // Злиття відсортованих частин
            ShellSort(array); 
        }

        static void ShellSortRange(int[] array, int start, int end)
        {
            int length = end - start;
            for (int gap = length / 2; gap > 0; gap /= 2)
            {
                for (int i = start + gap; i < end; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= start + gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
        }
        static int[] GenerateRandomArray(int size)
        {
            Random rnd = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rnd.Next(1, 10000);
            return array;
        }
    }
}
