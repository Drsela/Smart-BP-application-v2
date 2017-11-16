using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            CalibrationValuesDTO latestValues = _businessLogic.GetCalibrationValuesFromDAL();
            Debug.WriteLine("Slope is :" + latestValues.Slope);
            Debug.WriteLine("Intercept is: " + latestValues.Intercept);
            /*
            dataQueue = new ConcurrentQueue<Datacontainer>();
            _businessLogic.startThreads(dataQueue);
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

<<<<<<< HEAD

        public Datacontainer getReadingsToGraph()
        {
             return _businessLogic.GetDatacontainer();
        }

        
        public List<double> getListToGraph()
        {
            return _businessLogic.returnTestList();
=======
        private void UpdateGraf()
        {
            Datacontainer grafContainer = _businessLogic.GetDatacontainer();
            List<double> grafList = grafContainer.getMVMeasaurement();

            for (int i = 0; i < grafList.Count; i++)
            {
                chart1.Series["Blodtryk"].Points.AddXY(counter, grafList[i]);
                counter = counter + 0.001;
            }
>>>>>>> dbaf1c7265f276f7e6755a5632b0c701a1bbf32f
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
