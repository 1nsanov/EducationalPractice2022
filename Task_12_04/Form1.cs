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
            series = new Series(Convert.ToString(rnd.Next(0, 1000)));
            series.ChartType = SeriesChartType.Line;
            series.ChartArea = "Graphic";
        }

        private void BuildGraphic(Series series)
        {
            var start = Convert.ToDouble(startBox.Text);
            var end = Convert.ToDouble(endBox.Text);
            if (start < 0.4) start = 0.4;
            if(end > 6) end = 6;
            for (double i = start; i <= end; i += Convert.ToDouble(stepBox.Text))
            {
                series.Points.AddXY(i, GetY(i));
            }
            label4.Text = $"Graphic: X from {start} to {end}";
            chart.Series.Add(series);
        }

        private double GetY(double x)
        {
            return Math.Pow(x, Math.Cos(x)) / (Math.Abs(x + Math.Pow(Math.E, x)) + Math.Tan(x));
        }

        private void selectFont_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK) SetFont(fontDialog);
        } 

        private void SetFont(FontDialog fontDialog)
        {
            label1.Font = fontDialog.Font;
            label2.Font = fontDialog.Font;
            label3.Font = fontDialog.Font;
            label4.Font = fontDialog.Font;
            buildGraphic.Font = fontDialog.Font;
            selectFont.Font = fontDialog.Font;
            startBox.Font = fontDialog.Font;
            endBox.Font = fontDialog.Font;
            stepBox.Font = fontDialog.Font;
        }
    }
}
