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
            if (Convert.ToInt32(SysTextBox.Text) >= 180 || Convert.ToInt32(DiaTextBox.Text) > 110)
            {
                DialogResult result =
                    MessageBox.Show(
                        "The entered values indicates severe hypertension. \nDo you want to continue?",
                        "Attention", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    sysValue = Convert.ToInt16(SysTextBox.Text);
                    diaValue = Convert.ToInt16(DiaTextBox.Text);

                    sysValue = sysValue * 1.2;
                    diaValue = diaValue * 0.8;

                    this.Close();
                }
            }

            else if (Convert.ToInt32(SysTextBox.Text) < 90 || Convert.ToInt32(DiaTextBox.Text) < 60)
            {
                DialogResult result =
                    MessageBox.Show(
                        "The entered values indicates severe hypotension. \nDo you want to continue?",
                        "Attention", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    sysValue = Convert.ToInt16(SysTextBox.Text);
                    diaValue = Convert.ToInt16(DiaTextBox.Text);

                    sysValue = sysValue * 1.2;
                    diaValue = diaValue * 0.8;

                    this.Close();
                }
            }


            else
            {
                sysValue = Convert.ToInt16(SysTextBox.Text);
                diaValue = Convert.ToInt16(DiaTextBox.Text);

                sysValue = sysValue * 1.2;
                diaValue = diaValue * 0.8;

                this.Close();
            }

           
        }

        public double getDia()
        {
            return diaValue;
        }

        public double getSys()
        {
            return sysValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
