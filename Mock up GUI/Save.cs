using System;
using System.Windows.Forms;
using BL;
using DTO;
using Interfaces;

namespace PL
{
    public partial class Save : Form
    {
        private readonly iBusinessLogic _businessLogic;
        private readonly SaveData _saveData;
        public EmployeeDTO _Employee;

        public Save(iBusinessLogic businessLogic, EmployeeDTO employee)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
            _saveData = new SaveData();
            _Employee = employee;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_saveData.ValidateCPR(CPRtextBox1.Text))
            {
                var allReadings = _businessLogic.ConvertReadingToBytes();
                _businessLogic.uploadEmployee(CPRtextBox1.Text, _Employee.ID, commentTextBox.Text, allReadings);
                Close();
            }
            else
            {
                MessageBox.Show("Wrong CPR-Number");
            }
        }
    }
}