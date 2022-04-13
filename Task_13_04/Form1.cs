using Helper;
using Newtonsoft.Json;

namespace Task_13_04
{
    public partial class Form1 : Form
    {
        private HexadecimalCounter? hexadecimalCounter = null;
        private const string NAME_FILE = "hexadecimal.json";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var value = dataSource.ParseIntForm(textBoxV.Text);
            var maxV = dataSource.ParseIntForm(textBoxMaxV.Text);
            var minV = dataSource.ParseIntForm(textBoxMinV.Text);
            hexadecimalCounter = HexadecimalCounter.SetValue(value, maxV, minV);
            SetupUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hexadecimalCounter = new HexadecimalCounter();
            SetupUI();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelMessage.Text = hexadecimalCounter.Increment();
            PrintValues();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelMessage.Text = hexadecimalCounter.Decrement();
            PrintValues();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            WriteToFile();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            ReadFromFile();
        }

        private void SetupUI()
        {
            button3.Enabled = true;
            button4.Enabled = true;
            ClearTextBoxes();
            PrintValues();
        }

        private void ClearTextBoxes()
        {
            textBoxV.Clear();
            textBoxMaxV.Clear();
            textBoxMinV.Clear();
        }

        private void PrintValues()
        {
            labelPrintValues.Text = hexadecimalCounter.PrintValues();
        }

        private void WriteToFile()
        {
            if(hexadecimalCounter != null)
            {
                File.WriteAllText(NAME_FILE, JsonConvert.SerializeObject(hexadecimalCounter));
                labelMessage.Text = "File saved";
            }
            else labelMessage.Text = "Counter is null";
        }
        private void ReadFromFile()
        {
            if (File.Exists(NAME_FILE))
            {
                hexadecimalCounter = JsonConvert.DeserializeObject<HexadecimalCounter>(File.ReadAllText(NAME_FILE));
                PrintValues();
                labelMessage.Text = "File loaded";
            }
            else labelMessage.Text = "File not found";
        } 
    }
}