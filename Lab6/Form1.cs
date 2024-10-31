using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private List<Result> resultList = new List<Result>();
        private object lockObject = new object();
        private double startX, endX, step;
        private int totalSteps1, totalSteps2;
        private System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            resultsDataGridView.DataSource = resultList;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += OnTimer_Tick;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(startTextBox.Text, out startX) ||
                !double.TryParse(endTextBox.Text, out endX) ||
                !double.TryParse(stepTextBox.Text, out step) ||
                startX >= endX || step <= 0)
            {
                MessageBox.Show("Некоректні значення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            resultList.Clear();
            resultsDataGridView.DataSource = null;
            resultsDataGridView.DataSource = resultList;
            progressBar1.Value = 0;
            progressBar2.Value = 0;

            totalSteps1 = totalSteps2 = 0;

            Task.Run(() => CalculatePartOne());
            Task.Run(() => CalculatePartTwo());
            timer.Start();
        }



        private void OnTimer_Tick(object sender, EventArgs e)
        {
            lock (timer)
            {
                int totalSteps = (int)((endX - startX) / step) + 1;
                progressBar1.Value = Math.Min((totalSteps1 * 100) / totalSteps, 100);
                progressBar2.Value = Math.Min((totalSteps2 * 100) / totalSteps, 100);
                resultsDataGridView.Refresh();

                if (totalSteps1 + totalSteps2 >= totalSteps)
                {
                    var sortedResults = resultList.OrderBy(r => r.X).ToList();
                    resultsDataGridView.DataSource = sortedResults;
                    timer.Stop();
                }
            }

        }
        private void CalculatePartOne()
        {
            for (double x = startX; x < 5 && x <= endX; x += step)
            {
                double result = PartOneFunction(x);

                lock (lockObject)
                {
                    resultList.Add(new Result { X = x, Value = result });
                    totalSteps1++;
                }

                Thread.Sleep(500);
            }
        }

        private void CalculatePartTwo()
        {

            for (double x = Math.Max(startX, 5); x <= endX; x += step)
            {
                double result = PartTwoFunction(x);

                lock (lockObject)
                {
                    resultList.Add(new Result { X = x, Value = result });
                    totalSteps2++;
                }

                Thread.Sleep(500);
            }


        }

        private double PartOneFunction(double x)
        {
            return 4 * (x * x) + 1;
        }

        private double PartTwoFunction(double x)
        {
            return (2 * x + 3) / (3 * (x * x) + 2 * x + 7);
        }
    }

    public class Result
    {
        public double X { get; set; }
        public double Value { get; set; }
    }
}
