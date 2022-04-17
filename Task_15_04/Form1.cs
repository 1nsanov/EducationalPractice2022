using Helper;

namespace Task_15_04
{
    public partial class Form1 : Form
    {
        public HexCounterManager? _hexCounterManager;
        private const string PATH = "hexadecimal.json";
        public static Action? UpdateAfterEdit;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _hexCounterManager = new HexCounterManager();
            _hexCounterManager.DefaultLoad(PATH);
            ReadFromFile();
            dataGridView.DataSource = _hexCounterManager.hexadecimalCounterList;
            UpdateAfterEdit += PrintValues;
            UpdateAfterEdit += UpdateData;
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
            MessageBox.Show($"You select counter:\n{_hexCounterManager.PrintValues()}");
            SetupUI();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!isSelectIdx()) return;
            var editFrom = new EditForm
            {
                _hexCounterManager = _hexCounterManager
            };
            editFrom.ShowDialog();
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

        public void PrintValues()
        {
            labelPrintValues.Text = _hexCounterManager.PrintValues();
        }

        private void WriteToFile()
        {
            labelFileMessage.Text = _hexCounterManager.WriteToFile(PATH);
        }
        private void ReadFromFile()
        {
            labelFileMessage.Text = _hexCounterManager.ReadFromFile(PATH);
        }

        public void UpdateData()
        {
            WriteToFile();
            ReadFromFile();
            dataGridView.DataSource = _hexCounterManager.hexadecimalCounterList;
        }
        private bool isSelectIdx()
        {
            if (_hexCounterManager.IsSelectIdx()) { labelError.Text = ""; return true; }
            labelError.Text = "Non select row";
            return false;
        }
    }
}