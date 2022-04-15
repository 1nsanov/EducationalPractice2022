
using Newtonsoft.Json;

namespace Task_11_04
{
    public partial class Form1 : Form
    {
        private List<Point>? Points { get; set; } = new();
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = Convert.ToInt32(textBox1.Text);
            if (count < 2) label4.Text = "Error: Count of points must be more than 1";
            else Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SetPoint();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            WriteToFile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReadFromFile();
        }
        
        private void Clear()
        {
            button1.Enabled = false;
            button2.Enabled = true;
            label5.Text = "Output:";
            label6.Text = "Points:";
            Points.Clear();
            textBox1.Clear();
        }


        private void SetPoint()
        {
            if (count > Points.Count)
            {
                var x = Convert.ToInt32(textBox2.Text);
                var y = Convert.ToInt32(textBox3.Text);
                Points.Add(new Point(x, y));
                textBox2.Clear();
                textBox3.Clear();
                if (count == Points.Count) ShowInfo();
            }
            else button2.Enabled = false;
        }

        private void ShowInfo()
        {
            Get—oefficientStraight();
            ShowPoints();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void ShowPoints()
        {
            var str = "";
            for (int i = 0; i < Points?.Count; i++)
            {
                str += $"Point {i + 1}: ({Points[i].X};{Points[i].Y})";
            }
            label6.Text = $"Points: {str}";
        }

        private void Get—oefficientStraight()
        {
            var coefficient = GetLenghtStraight() / GetLengthLine();
            if (coefficient == 1) label5.Text = $"ÀËÌËˇ ÔˇÏ‡ˇ! ÍÓ˝Ù = {coefficient}";
            else label5.Text = $"ÀËÌËˇ ÌÂ ÔˇÏ‡ˇ! ÍÓ˝Ù = {coefficient}";
        }

        private double GetLenghtStraight()
        {
            return GetLengthVector(Points[0], Points[Points.Count - 1]);
        }

        private double GetLengthLine()
        {
            var lengthLine = 0.0;
            for (int i = 0; i < Points.Count - 1; i++)
            {
                lengthLine += GetLengthVector(Points[i], Points[i + 1]);
            }
            return lengthLine;
        }
        private double GetLengthVector(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        private void WriteToFile()
        {
            if(Points.Count > 0)
            {
                File.WriteAllText("point.json", JsonConvert.SerializeObject(Points));
                label7.Text = "File point.json was created";
            }
            else label4.Text = $"Error: Points is empty";
        }
        private void ReadFromFile()
        {
            try
            {
                Points = JsonConvert.DeserializeObject<List<Point>>(File.ReadAllText("point.json"));
                ShowInfo();
                label7.Text = "File point.json was read";
                
            }
            catch (Exception e)
            {
                label4.Text = $"{e.Message}";
            }
        }
    }
}