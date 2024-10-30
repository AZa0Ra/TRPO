using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace Lab5
{

    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private readonly List<Results> results = new List<Results>();
        private int tickCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            resultsDataGrid.ItemsSource = results;
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            results.Clear();
            resultsDataGrid.Items.Refresh();

            if (!int.TryParse(inputText.Text, out int startValue) || startValue < 0)
            {
                MessageBox.Show("Недопустиме значення! Введіть невід'ємне ціле число.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //myTimer = new MyTimer(1000, OnFunctionCalculate); 
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += Timer_Tick;
            //myTimer.Start();
            timer.Start();
            _ = Task.Delay(startValue * 1000).ContinueWith(_ => Dispatcher.Invoke(() => timer.Stop()));

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            double argument = tickCount + 1;
            double result = CalculateFunction(argument);
            results.Add(new Results { Argument = argument, Result = result });
            Dispatcher.Invoke(() => resultsDataGrid.Items.Refresh());
            tickCount++;
        }

        private double CalculateFunction(double x)
        {
            if (x < 5)
            {
                return 4 * (x * x) + 1;
            }
            else
            {
                return (2 * x + 3) / (3 * (x * x) + 2 * x + 7);
            }
        }
    }
    public class Results
    {
        public double Argument { get; set; }
        public double Result { get; set; }
    }
}