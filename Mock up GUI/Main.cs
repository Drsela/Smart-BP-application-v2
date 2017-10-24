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

namespace PL
{
    public partial class Main : Form
    {
        private iBusinessLogic _businessLogic;
        public Main(iBusinessLogic businessLogic)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Series 1"].Points.AddXY(1, 3);
            chart1.Series["Series 1"].Points.AddXY(3, 6);
            chart1.Series["Series 1"].Points.AddXY(5, 3);
            chart1.Series["Series 1"].Points.AddXY(7, 6);
            chart1.Series["Series 1"].Points.AddXY(9, 3);
            chart1.Series["Series 1"].Points.AddXY(11, 6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Application.Run(new Save());
            Login formLogin = new Login(_businessLogic);
            formLogin.Show();
        }
    }
}
