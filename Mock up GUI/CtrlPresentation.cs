using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Windows.Forms;
using PL;

namespace PL
{
    public class CtrlPresentation : iPresentationLogic
    {
        //private iBusinessLogic currentBL;
        public Main _myMain;
        public iBusinessLogic currentBL { set; get; }
        public CtrlPresentation(iBusinessLogic mybl)
        {
            this.currentBL = mybl;
            Application.SetCompatibleTextRenderingDefault(false);
            _myMain = new Main(currentBL);
        }
        public void startUpGUI()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.Run(_myMain);
        }

    }
}
