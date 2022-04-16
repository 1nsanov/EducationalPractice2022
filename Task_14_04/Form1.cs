using Helper;
using Newtonsoft.Json;

namespace Task_14_04
{
    public partial class Form1 : Form
    {
        public int curIdx = 0;
        public List<HexadecimalCounter> hexadecimalCounterList = new List<HexadecimalCounter>();
        private const string NAME_FILE = "hexadecimal.json";
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(NAME_FILE))
            {
                File.Create(NAME_FILE).Close();
                File.WriteAllText(NAME_FILE, "[]");
            }
            ReadFromFile();
            UpdateData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var value = dataSource.ParseIntForm(textBoxV.Text);
            var maxV = dataSource.ParseIntForm(textBoxMaxV.Text);
            var minV = dataSource.ParseIntForm(textBoxMinV.Text);
            hexadecimalCounterList.Add(HexadecimalCounter.SetValue(value, maxV, minV));
            UpdateData();
            SetupUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hexadecimalCounterList.Add(new HexadecimalCounter());
            UpdateData();
            SetupUI();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelMessage.Text = hexadecimalCounterList[curIdx].Increment();
            PrintValues();
            UpdateData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelMessage.Text = hexadecimalCounterList[curIdx].Decrement();
            PrintValues();
            UpdateData();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            WriteToFile();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            ReadFromFile();
            UpdateData();
        }
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            curIdx = hexadecimalCounterList.FindIndex(x => x.Id == dataGridView.CurrentRow.Cells[0].Value.ToString());
            SetupUI();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ModeEdit(true);
            textBox1.Text = HexadecimalCounter.ConvertFromHex(hexadecimalCounterList[curIdx].Value).ToString();
            textBox2.Text = HexadecimalCounter.ConvertFromHex(hexadecimalCounterList[curIdx].MaxValue).ToString();
            textBox3.Text = HexadecimalCounter.ConvertFromHex(hexadecimalCounterList[curIdx].MinValue).ToString();
        }

        private void buttonAcceptEdit_Click(object sender, EventArgs e)
        {
            hexadecimalCounterList[curIdx].Value = HexadecimalCounter.ConvertToHex(dataSource.ParseIntForm(textBox1.Text));
            hexadecimalCounterList[curIdx].MaxValue = HexadecimalCounter.ConvertToHex(dataSource.ParseIntForm(textBox2.Text));
            hexadecimalCounterList[curIdx].MinValue = HexadecimalCounter.ConvertToHex(dataSource.ParseIntForm(textBox3.Text));
            ModeEdit(false);
            UpdateData();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            hexadecimalCounterList.RemoveAt(curIdx);
            UpdateData();
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
            if(hexadecimalCounterList[curIdx] != null) labelPrintValues.Text = hexadecimalCounterList[curIdx].PrintValues();
        }

        private void WriteToFile()
        {
            if (hexadecimalCounterList != null)
            {
                File.WriteAllText(NAME_FILE, JsonConvert.SerializeObject(hexadecimalCounterList));
                labelMessage.Text = "File saved";
            }
            else labelMessage.Text = "List is null";
        }
        private void ReadFromFile()
        {
            if (File.Exists(NAME_FILE))
            {
                hexadecimalCounterList = JsonConvert.DeserializeObject<List<HexadecimalCounter>>(File.ReadAllText(NAME_FILE));
                labelMessage.Text = "File loaded";
            }
            else labelMessage.Text = "File not found";
        }
        
        private void UpdateData()
        {
            WriteToFile();
            dataGridView.DataSource = hexadecimalCounterList;
            ReadFromFile();
        }

        private void ModeEdit(bool mode)
        {
            textBox1.Enabled = mode;
            textBox2.Enabled = mode;
            textBox3.Enabled = mode;
            buttonAcceptEdit.Enabled = mode;
        }
    }
}