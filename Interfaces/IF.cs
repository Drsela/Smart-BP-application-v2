using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface iDataAccessLogic
    {
        int getSomeData();//Signatur
        void saveSomeData(int val);
    }
    public interface iBusinessLogic
    {
        void doAnAlogrithm();
        void startThreads();
    }

    public interface iPresentationLogic
    {
        void startUpGUI();
    }
}
