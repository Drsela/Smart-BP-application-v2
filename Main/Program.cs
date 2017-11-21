using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using PL;
using DAL;
using DTO;
using Interfaces;


namespace Main
{
    class Program
    {
        private CtrlPresentation currentGUIPL;
        private CtrlBusinessLogic currentBL;
        private CtrlDataAccessLogic currentDAL;
        private ConcurrentQueue<Datacontainer> dataQueue;
        static void Main(string[] args)
        {
            Program currentApp = new Main.Program();
        }

        public Program()
        {
            dataQueue = new ConcurrentQueue<Datacontainer>();
            currentDAL = new CtrlDataAccessLogic();
            currentBL = new CtrlBusinessLogic(currentDAL,dataQueue);
            currentGUIPL = new CtrlPresentation(currentBL);
            
            currentGUIPL.startUpGUI();
        }
    }
}
