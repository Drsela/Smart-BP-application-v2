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
        private iBusinessLogic currentBL;
        public CtrlPresentation(iBusinessLogic mybl)
        {
            this.currentBL = mybl;
        }
        public void startUpGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.DoEvents();
            Application.Run(new Main(currentBL));
        }
    }
}
