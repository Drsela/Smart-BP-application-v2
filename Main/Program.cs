using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using PL;
using DAL;
using Interfaces;


namespace Main
{
    class Program
    {
        private CtrlPresentation currentGUIPL;
        private CtrlBusinessLogic currentBL;
        private CtrlDataAccessLogic currentDAL;
        static void Main(string[] args)
        {
            Program currentApp = new Main.Program();
        }

        public Program()
        {
            currentDAL = new CtrlDataAccessLogic();
            currentBL = new CtrlBusinessLogic(currentDAL);
            currentGUIPL = new CtrlPresentation(currentBL);
            currentGUIPL.startUpGUI();
        }
    }
}
