using Helper;


namespace Task_14_04
{
    public partial class Form1 : Form
    {
        public HexCounterManager _hexCounterManager;
        private const string PATH = "hexadecimal.json";
        public Form1()
        {
            InitializeComponent();
            _hexCounterManager = new HexCounterManager();
            _hexCounterManager.DefaultLoad(PATH);
            ReadFromFile();
            dataGridView.DataSource = _hexCounterManager.hexadecimalCounterList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var value = dataSource.ParseIntForm(textBoxV.Text);
            var maxV = dataSource.ParseIntForm(textBoxMaxV.Text);
            var minV = dataSource.ParseIntForm(textBoxMinV.Text);
            _hexCounterManager.AddCounter(value, maxV, minV);
            _hexCounterManager.SetCurrentIndex(_hexCounterManager.hexadecimalCounterList.Count - 1);
            UpdateData();
            SetupUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _hexCounterManager.AddCounter();
            _hexCounterManager.SetCurrentIndex(_hexCounterManager.hexadecimalCounterList.Count - 1);
            UpdateData();
            SetupUI();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelMessage.Text = _hexCounterManager.IncrementCurrent();
            PrintValues();
            UpdateData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelMessage.Text = _hexCounterManager.DecrementCurrent();
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
            _hexCounterManager.SetCurrentIndex(dataGridView.CurrentRow.Cells[0].Value.ToString());
            SetupUI();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!isSelectIdx()) return;
            ModeEdit(true);
            var result = _hexCounterManager.GetForEditCounter();
            textBox1.Text = result[0];
            textBox2.Text = result[1];
            textBox3.Text = result[2];
        }

        private void buttonAcceptEdit_Click(object sender, EventArgs e)
        {
            var value = dataSource.ParseIntForm(textBox1.Text);
            var maxValue = dataSource.ParseIntForm(textBox2.Text);
            var minValue = dataSource.ParseIntForm(textBox3.Text);
            if (value > maxValue || value < minValue || maxValue < minValue)
            {
                MessageBox.Show("Incorrect values. Please, try again.");
                return;
            }
            _hexCounterManager.EditCurrent(HexadecimalCounter.ConvertToHex(value),
                                           HexadecimalCounter.ConvertToHex(maxValue),
                                           HexadecimalCounter.ConvertToHex(minValue));
            ModeEdit(false);
            PrintValues();
            UpdateData();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (!isSelectIdx()) return;
             _hexCounterManager.RemoveCurrent();
            button3.Enabled = false;
            button4.Enabled = false;
            labelPrintValues.Text = "";
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
            labelPrintValues.Text = _hexCounterManager.GetCurrentValues();
        }

        private void WriteToFile()
        {
            labelFileMessage.Text = _hexCounterManager.WriteToFile(PATH);
        }
        private void ReadFromFile()
        {
            labelFileMessage.Text = _hexCounterManager.ReadFromFile(PATH);
        }

        private void UpdateData()
        {
            WriteToFile();
            ReadFromFile();
            dataGridView.DataSource = _hexCounterManager.hexadecimalCounterList;
        }

        private void ModeEdit(bool mode)
        {
            textBox1.Enabled = mode;
            textBox2.Enabled = mode;
            textBox3.Enabled = mode;
            buttonAcceptEdit.Enabled = mode;
            if (!mode)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }
        private bool isSelectIdx()
        {
            if (_hexCounterManager.IsSelectIdx()) { labelError.Text = ""; return true; }
            labelError.Text = "Non select row";
            return false;
        }
    }
}