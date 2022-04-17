using Helper;

namespace Task_15_04
{
    public partial class EditForm : Form
    {
        public HexCounterManager? _hexCounterManager;
        public EditForm()
        {
            InitializeComponent();
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
            Form1.UpdateAfterEdit?.Invoke();
            MessageBox.Show("Edit successful");
            Close();
        }

        private void buttonCancelAccept_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void InitValues()
        {
            var result = _hexCounterManager.GetForEditCounter();
            textBox1.Text = result[0];
            textBox2.Text = result[1];
            textBox3.Text = result[2];
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            InitValues();
        }
    }
}
