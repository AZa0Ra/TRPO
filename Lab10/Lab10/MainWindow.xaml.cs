using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab10
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

        private double CalculateTerm(int i)
        {
            double term = ((-1) * Math.Pow(i, 1) + 1) * (Math.Cos(1.5 * i) / Math.Pow(i, 2));
            term *= (1 + Math.Log(i) / Math.Pow(2 * Math.Pow(i, 2) + 1, 2) - Math.Exp(-i));
            return term;
        }

        private double SequentialReduction(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += CalculateTerm(i);
            }
            return sum;
        }

        private double ParallelReductionSlower(int n)
        {
            double sum = 0;
            var tasks = new Task<double>[n];

            for (int i = 0; i < n; i++)
            {
                int index = i + 1;
                tasks[i] = Task.Run(() =>
                {
                    return CalculateTerm(index);
                });
            }

            Task.WhenAll(tasks).Wait();

            foreach (var task in tasks)
            {
                sum += task.Result;
            }
            return sum;
        }

        private double ParallelReduction(int n)
        {
            object lockObj = new object();
            double sum = 0;
            Parallel.For(1, n + 1, i =>
            {
                double term = CalculateTerm(i);
                lock (lockObj)
                {
                    sum += term;
                }
            });
            return sum;
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int n = 24000; // 24 число мого варіанту
            int p = Environment.ProcessorCount;

            ResultTextBlock.Text = string.Empty;
            SequentialTimeTextBlock.Text = string.Empty;
            ParallelTimeTextBlock.Text = string.Empty;
            SpeedupTextBlock.Text = string.Empty;
            EfficiencyTextBlock.Text = string.Empty;
            AmdahlTextBlock.Text = string.Empty;
            GustafsonTextBlock.Text = string.Empty;

            Stopwatch stopwatch = new Stopwatch();

            // Послідовне 
            stopwatch.Start();
            double sequentialResult = SequentialReduction(n);
            stopwatch.Stop();
            double sequentialTime = stopwatch.Elapsed.TotalMilliseconds;
            SequentialTimeTextBlock.Text = $"Sequential Time: {sequentialTime:F6} ms";

            // Паралельне 
            stopwatch.Restart();
            double parallelResult = ParallelReduction(n);
            stopwatch.Stop();
            double parallelTime = stopwatch.Elapsed.TotalMilliseconds;
            ParallelTimeTextBlock.Text = $"Parallel Time: {parallelTime:F6} ms";

            double speedup = sequentialTime / parallelTime;
            double efficiency = speedup / p;
            SpeedupTextBlock.Text = $"Speedup: {speedup:F6}";
            EfficiencyTextBlock.Text = $"Efficiency: {efficiency:F6}";

            double S_Amdahl = 1 / ((1 - (1 / speedup)) + (1 / p));
            AmdahlTextBlock.Text = $"Amdahl's Speedup: {S_Amdahl:F6}";

            double S_Gustafson = (1 - (1 / p)) * speedup + (1 / p);
            GustafsonTextBlock.Text = $"Gustafson-Barsis Speedup: {S_Gustafson:F6}";

            ResultTextBlock.Text = $"Scalar product result: {sequentialResult}\nParallel product result: {parallelResult}";
        }
    }
}
