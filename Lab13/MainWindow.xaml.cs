using System.Diagnostics;
using System.Windows;

using LiveCharts;
using LiveCharts.Wpf;

namespace Lab13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[] baseArray = { 6, 18, 6, 18, 3, 25, 3, 25, 96, 81, 4, -1, 85, 4, 45, 47 };


        public static double MeasureLatency(int numThreads)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Parallel.For(0, 1, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, i => { });

            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        }

        public static double MeasureThroughput(Action sortAction, int dataSize, out double elapsedSeconds)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sortAction();
            sw.Stop();
            elapsedSeconds = sw.Elapsed.TotalSeconds;

            return dataSize / elapsedSeconds;
        }

        public static double MeasureBasicOperationTime(int[] data, int numThreads, out int comparisonCount)
        {
            int count = 0;
            object lockObj = new();

            int n = data.Length;
            int[] array = (int[])data.Clone();

            Stopwatch sw = Stopwatch.StartNew();

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                Parallel.For(0, gap, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, i =>
                {
                    for (int j = i + gap; j < n; j += gap)
                    {
                        int temp = array[j];
                        int k = j;
                        while (k >= gap && array[k - gap] > temp)
                        {
                            lock (lockObj) { count++; }
                            array[k] = array[k - gap];
                            k -= gap;
                        }
                        lock (lockObj) { count++; } 
                        array[k] = temp;
                    }
                });
            }

            sw.Stop();
            comparisonCount = count;

            return sw.Elapsed.TotalMilliseconds / comparisonCount;
        }

        public static void ParallelShellSort(int[] array, int numThreads)
        {
            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                Parallel.For(0, gap, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, i =>
                {
                    for (int j = i + gap; j < n; j += gap)
                    {
                        int temp = array[j];
                        int k = j;
                        while (k >= gap && array[k - gap] > temp)
                        {
                            array[k] = array[k - gap];
                            k -= gap;
                        }
                        array[k] = temp;
                    }
                });
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            int[] threads = { 1, 2, 8 };
            double[] times = new double[threads.Length];

            for (int i = 0; i < threads.Length; i++)
            {
                int[] arrayCopy = (int[])baseArray.Clone();
                int threadCount = threads[i];
                Stopwatch sw = Stopwatch.StartNew();
                ParallelShellSort(arrayCopy, threadCount);
                sw.Stop();
                times[i] = sw.Elapsed.TotalMilliseconds;
            }

            double baseTime = times[0];

            int[] data = { 6, 18, 6, 18, 3, 25, 3, 25, 96, 81, 4, -1, 85, 4, 45, 47 };

            // Латентність
            double latency = MeasureLatency(8);

            // Пропускна здатність
            double throughput = MeasureThroughput(() =>
            {
                ParallelShellSort((int[])data.Clone(), 8);
            }, data.Length, out double sortTime);

            // Час базової операції
            double opTime = MeasureBasicOperationTime(data, 8, out int comparisons);

            TimeResultTextBlock.Text = $"Метрики продуктивності:\n\n" +
                $"Латентність (8 потоків): {latency:F3} мс\n" +
                $"Пропускна здатність: {throughput:F2} ел/сек\n" +
                $"Час 1 порівняння: {opTime:F6} мс\n" +
                $"Всього порівнянь: {comparisons}\n" +
                $"Час (1 потік): {times[0]:0.00000} мс\n" +
                $"Час (2 потоки): {times[1]:0.00000} мс\n" +
                $"Час (8 потоків): {times[2]:0.00000} мс";


            // S = T1 / Tn 
            SpeedupChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Прискорення",
                    Values = new ChartValues<double>(threads.Select((t, i) => baseTime / times[i]))
                }
            };

            SpeedupChart.AxisX.Clear();
            SpeedupChart.AxisX.Add(new Axis
            {
                Title = "Кількість потоків",
                Labels = threads.Select(t => t.ToString()).ToArray()
            });

            SpeedupChart.AxisY.Clear();
            SpeedupChart.AxisY.Add(new Axis
            {
                Title = "Прискорення"
            });
        }
    }
}