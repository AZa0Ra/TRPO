using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace Lab11
{
    /// <summary>
    /// Треба встановити NuGet - LiveCharts.Wpf
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChartValues<double> _timeDataN;
        private ChartValues<double> _timeDataM;

        public ChartValues<double> TimeDataN
        {
            get => _timeDataN;
            set
            {
                _timeDataN = value;
                OnPropertyChanged(nameof(TimeDataN));
            }
        }

        public ChartValues<double> TimeDataM
        {
            get => _timeDataM;
            set
            {
                _timeDataM = value;
                OnPropertyChanged(nameof(TimeDataM));
            }
        }


        public SeriesCollection SeriesCollectionN { get; set; }
        public SeriesCollection SeriesCollectionM { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            TimeDataN = new ChartValues<double>();
            TimeDataM = new ChartValues<double>();

            SeriesCollectionN = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Time vs n",
                    Values = TimeDataN
                }
            };

            SeriesCollectionM = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Time vs m",
                    Values = TimeDataM
                }
            };

            DataContext = this;
        }

        private void RunExperiments_Click(object sender, RoutedEventArgs e)
        {
            ResultsList.Items.Clear();
            TimeDataN.Clear();
            TimeDataM.Clear();
            double x = 2.0;

            for (int i = 1; i <= 5; i++)
            {
                int n = i * 5;
                int m = 15;
                RunExperiment(n, m, x, true);
            }

            for (int i = 1; i <= 5; i++)
            {
                int n = 5;
                int m = i * 5;
                RunExperiment(n, m, x, false);
            }
        }
        private void RunExperiment(int n, int m, double x, bool isNVariable)
        {
            double[,] A = new double[m, n];
            double[] B = new double[n];
            double[] C = new double[m];

            // B
            for (int j = 0; j < n; j++)
            {
                B[j] = (Math.Pow(3, j) - Math.Pow(x, 0.3) + 1) / (j + Math.Pow(Math.Cos(Math.Pow(5 * j, 0.3)), 2));
            }

            //  A
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = (Math.Pow(j, 3) + 1) / (i + Math.Pow(Math.Cos(Math.Pow(x, 0.3)), 2)) + x * x;
                }
            }

            var sw = Stopwatch.StartNew();

            Parallel.For(0, m, i =>
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += A[i, j] * B[j];
                }
                C[i] = sum;
            });

            sw.Stop();
            long elapsedMs = sw.ElapsedMilliseconds;

            ResultsList.Items.Add($"n={n}, m={m}, Time: {elapsedMs:F10} ms");

            if (isNVariable)
                TimeDataN.Add(elapsedMs);
            else
                TimeDataM.Add(elapsedMs);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
