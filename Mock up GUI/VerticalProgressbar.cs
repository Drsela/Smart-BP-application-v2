using System.Windows.Forms;

namespace Mock_up_GUI
{
    public class VerticalProgressbar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }
    }
}