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
using Interfaces;
using DTO;

namespace PL
{
    public partial class Main : Form, iPatentConsumerObserver
    {
        private iBusinessLogic _businessLogic;
        private GraphDTO _graphDTO;
        private ConcurrentQueue<Datacontainer> dataQueue;
        private double counter;
        private AlarmDTO _alarm;
        private Datacontainer measurements;
        



        public Main(iBusinessLogic businessLogic)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
            _graphDTO = new GraphDTO();
            _alarm = new AlarmDTO();
            counter = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataQueue = new ConcurrentQueue<Datacontainer>();
            _businessLogic.startThreads(dataQueue);


            //_businessLogic.startAlarm(_alarm);

            /*
            Thread graphThread = new Thread(UpdateGraph) {IsBackground = true};
            graphThread.Start();
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
            _alarm.setUpperLimit(upperTrackBar.Value);
        }

        private void lowerTrackBar_Scroll(object sender, EventArgs e)
        {
            LowerlimitText.Text = Convert.ToString(lowerTrackBar.Value);
            _alarm.setUpperLimit(lowerTrackBar.Value);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _businessLogic.stopThreads();
        }


        public Datacontainer getReadingsToGraph()
        {
             return _businessLogic.GetDatacontainer();
        }

        
        public List<double> getListToGraph()
        {
            return _businessLogic.returnTestList();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            Calibrate calibrateWindow = new Calibrate(_businessLogic);
            calibrateWindow.Show();
        }


        public void UpdateGraph()
        {
            
        }

        public void Update(GraphDTO GraphData)
        {
            
        }
    }
}
