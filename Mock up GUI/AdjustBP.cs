using System;
using System.Windows.Forms;

namespace PL
{
    public partial class AdjustBP : Form
    {
        private Form _mainForm;
        private double diaValue;
        private double sysValue;

        public AdjustBP(Form mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        public void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SysTextBox.Text) >= 180 || Convert.ToInt32(DiaTextBox.Text) >= 110)
            {
                var result =
                    MessageBox.Show(
                        "The entered values indicates severe hypertension.",
                        "Attention", MessageBoxButtons.OK);
               
                    sysValue = Convert.ToInt16(SysTextBox.Text);
                    diaValue = Convert.ToInt16(DiaTextBox.Text);

                    sysValue = sysValue * 1.2;
                    diaValue = diaValue * 0.8;

                    Close();
                
            }

            else if (Convert.ToInt32(SysTextBox.Text) <= 90 || Convert.ToInt32(DiaTextBox.Text) <= 60)
            {
                var result =
                    MessageBox.Show(
                        "The entered values indicates severe hypotension.",
                        "Attention", MessageBoxButtons.OK);
             
                    sysValue = Convert.ToInt16(SysTextBox.Text);
                    diaValue = Convert.ToInt16(DiaTextBox.Text);

                    sysValue = sysValue * 1.2;
                    diaValue = diaValue * 0.8;
                    Close();
            }


            else
            {
                sysValue = Convert.ToInt16(SysTextBox.Text);
                diaValue = Convert.ToInt16(DiaTextBox.Text);

                sysValue = sysValue * 1.2;
                diaValue = diaValue * 0.8;

                Close();
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
            Close();
        }
    }
}