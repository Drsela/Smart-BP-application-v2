using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DAL;
using Interfaces;
using DTO;

namespace PL
{
    public partial class Main : Form
    {
        private iBusinessLogic _businessLogic;
        private ConcurrentQueue<Datacontainer> dataQueue;

        public Main(iBusinessLogic businessLogic)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataQueue = new ConcurrentQueue<Datacontainer>();

            _businessLogic.startThreads(dataQueue);
            //_ctrlBusinessLogic.startThreads();


            /*
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
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login(_businessLogic);
            formLogin.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void upperTrackBar_Scroll(object sender, EventArgs e)
        {
            UpperlimitText.Text = Convert.ToString(upperTrackBar.Value);
        }

        private void lowerTrackBar_Scroll(object sender, EventArgs e)
        {
            LowerlimitText.Text = Convert.ToString(lowerTrackBar.Value);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _businessLogic.stopThreads();
        }
    }
}
