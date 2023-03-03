using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Task_12_04
{
    public partial class Form1 : Form
    {
        private static Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart.ChartAreas.Add(new ChartArea("Graphic"));
        }

        private void buildGraphic_Click(object sender, EventArgs e)
        {
            InitChart(out Series series);
            BuildGraphic(series);
        }

        private void InitChart(out Series series)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.Minimum = -10; // минимальное значение по оси X
            chart.ChartAreas[0].AxisX.Maximum = 10; // максимальное значение по оси X
            chart.ChartAreas[0].AxisX.Interval = 1; // шаг по оси X
            chart.ChartAreas[0].AxisX.Title = "x"; // название оси X
            chart.ChartAreas[0].AxisY.Minimum = -2; // минимальное значение по оси Y
            chart.ChartAreas[0].AxisY.Maximum = 2; // максимальное значение по оси Y
            chart.ChartAreas[0].AxisY.Interval = 1; // шаг по оси Y
            chart.ChartAreas[0].AxisY.Title = "y"; // название оси Y
            series = new Series(Convert.ToString(rnd.Next(0, 1000)));
            series.ChartType = SeriesChartType.Line;
            series.ChartArea = "Graphic";
        }

        private void BuildGraphic(Series series)
        {
            var start = Convert.ToDouble(startBox.Text);
            var end = Convert.ToDouble(endBox.Text);
            for (double i = start; i <= end; i += Convert.ToDouble(stepBox.Text))
            {
                series.Points.AddXY(i, GetY(i));
            }
            label4.Text = $"Graphic: X from {start} to {end}";
            chart.Series.Add(series);
        }

        private double GetY(double x)
        {
            return Math.Sin(x) + Math.Cos(4 * x);
        }
    }
}
