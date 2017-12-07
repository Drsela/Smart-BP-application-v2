using System;
using System.Windows.Forms;
using BL;
using Interfaces;

namespace PL
{
    public partial class Login : Form
    {
        private readonly iBusinessLogic _businessLogic;
        private readonly SaveData _saveData;

        public Login(iBusinessLogic businessLogic)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
            _saveData = new SaveData();
        }

        private void button3_Click(object sender, EventArgs e) // Login button
        {
            if (_saveData.ValidateLogin(EmployeeID.Text, Password.Text))
            {
                var formSave = new Save(_businessLogic,
                    _saveData.GetEmployeeFromValidation(EmployeeID.Text, Password.Text));
                Close();
                formSave.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login \nPlease try again");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button3_Click(this, new EventArgs());
        }
    }
}