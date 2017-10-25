using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    public class CtrlBusinessLogic : iBusinessLogic
    {
        private iDataAccessLogic currentDal;
        public CtrlBusinessLogic(iDataAccessLogic mydal)
        {
            this.currentDal = mydal;
        }
        public void doAnAlogrithm()
        {
            
        }
    }
}
