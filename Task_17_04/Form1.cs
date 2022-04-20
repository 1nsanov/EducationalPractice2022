using Helper;

namespace Task_16_04
{
    public partial class Form1 : Form
    {
        public HexCounterManager? _hexCounterManager;
        private string PATH = "hexadecimal.json";
        public static Action? UpdateAfterEdit;
        private DateTime TimeEnd = new DateTime(2022, 4, 16, 10, 0, 0);
        public Form1()
        {
            InitializeComponent();
            textBoxV.KeyPress += InputOnlyNumbers;
            textBoxMaxV.KeyPress += InputOnlyNumbers;
            textBoxMinV.KeyPress += InputOnlyNumbers;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _hexCounterManager = new HexCounterManager();
            _hexCounterManager.DefaultLoad(PATH);
            ReadFromFile();
            dataGridView.DataSource = _hexCounterManager.hexadecimalCounterList;
            UpdateAfterEdit += PrintValues;
            UpdateAfterEdit += UpdateData;

            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            var value = dataSource.ParseIntForm(textBoxV.Text);
            var maxV = dataSource.ParseIntForm(textBoxMaxV.Text);
            var minV = dataSource.ParseIntForm(textBoxMinV.Text);
            if (value > maxV || value < minV || maxV < minV)
            {
                MessageBox.Show("Incorrect values. Please, try again.");
                return;
            }
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
            SaveFile();
            WriteToFile();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFile();
            ReadFromFile();
            dataGridView.DataSource = _hexCounterManager.hexadecimalCounterList;
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

        private void OpenFile()
        {
            var openDialog = new OpenFileDialog
            {
                Title = "Select A File",
                Filter = "Json Files (*.json)|*.*"
            };
            if (openDialog.ShowDialog() == DialogResult.OK) PATH = openDialog.FileName;
        }
        private void SaveFile()
        {
            var saveDialog = new SaveFileDialog
            {
                Title = "Select A File",
                Filter = "Json Files (*.json)|*.*"
            };
            if (saveDialog.ShowDialog() == DialogResult.OK) PATH = saveDialog.FileName;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            var timeRemaining = TimeEnd - DateTime.Now;
            labelTimeEnd.Text = $"Left time: {timeRemaining.ToString(@"d\:hh\:mm\:ss")}";
            labelCurrentDate.Text = $"Current date: {DateTime.Now.ToString(@"dd/MM/yyyy HH:mm:ss")} Weekday: {DateTime.Now.DayOfWeek}";
            if (timeRemaining.TotalSeconds <= 0) labelTimeEnd.Text = "Time is over"; 
        }

        public void InputOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}