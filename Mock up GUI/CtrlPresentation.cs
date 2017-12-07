using System.Windows.Forms;
using Interfaces;

namespace PL
{
    public class CtrlPresentation : iPresentationLogic
    {
        //private iBusinessLogic currentBL;
        public Main _myMain;

        public CtrlPresentation(iBusinessLogic mybl)
        {
            currentBL = mybl;
            Application.SetCompatibleTextRenderingDefault(false);
            _myMain = new Main(currentBL);
        }

        public iBusinessLogic currentBL { set; get; }

        public void startUpGUI()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.Run(_myMain);
        }
    }
}