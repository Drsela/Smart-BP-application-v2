using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using BL;

namespace PL
{
    public partial class Save : Form
    {
        private iBusinessLogic _businessLogic;
        private SaveData _saveData;
        public Save(iBusinessLogic businessLogic)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
            _saveData = new SaveData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_saveData.ValidateCPR(CPRtextBox1.Text) == true)
                MessageBox.Show("Success");
            else
            {
                MessageBox.Show("Wrong CPR-Number");
            }
        }
    }
}
