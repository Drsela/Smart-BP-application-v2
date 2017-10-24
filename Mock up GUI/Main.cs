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
            chart1.Series[0].Points.Clear();
            Random testRandom = new Random();
            int t = 1;
            for (int i = 0; i < 20; i++)
            {
                int sys = testRandom.Next(100, 220);
                int dia = testRandom.Next(50, 100);
                chart1.Series["Series 1"].Points.AddXY(t, sys);
                chart1.Series["Series 1"].Points.AddXY(t+0.5, dia);
                t++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login(_businessLogic);
            formLogin.Show();
        }
    }
}
