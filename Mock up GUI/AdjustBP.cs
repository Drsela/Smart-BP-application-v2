using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PL;

namespace PL
{
    public partial class AdjustBP : Form
    {
        private Form _mainForm;
        private double sysValue;
        private double diaValue;
        public AdjustBP(Form mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            sysValue = Convert.ToInt16(SysTextBox.Text);
            diaValue = Convert.ToInt16(DiaTextBox.Text);

            sysValue = sysValue * 1.2;
            diaValue = diaValue * 0.8;

            this.Close();
        }

        public double getDia()
        {
            return diaValue;
        }

        public double getSys()
        {
            return sysValue;
        }
    }
}
