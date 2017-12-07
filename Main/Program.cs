using System.Collections.Concurrent;
using BL;
using DAL;
using DTO;
using PL;

namespace Main
{
    internal class Program
    {
        private readonly CtrlBusinessLogic currentBL;
        private readonly CtrlDataAccessLogic currentDAL;
        private readonly CtrlPresentation currentGUIPL;
        private readonly ConcurrentQueue<Datacontainer> dataQueue;

        public Program()
        {
            dataQueue = new ConcurrentQueue<Datacontainer>();
            currentDAL = new CtrlDataAccessLogic();
            currentBL = new CtrlBusinessLogic(currentDAL, dataQueue);
            currentGUIPL = new CtrlPresentation(currentBL);

            currentGUIPL.startUpGUI();
        }

        private static void Main(string[] args)
        {
            var currentApp = new Program();
        }
    }
}