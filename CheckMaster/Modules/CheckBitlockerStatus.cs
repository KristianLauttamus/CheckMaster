using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckMaster.Restrictions;

namespace CheckMaster.Modules
{
    class CheckBitlockerStatus : MasterModule
    {
        private Status status;

        public override void init()
        {
            this.status = Status.NOTRUN;
        }

        public override void check()
        {
            if (WMIController.checkBitLockerStatus())
            {
                this.status = Status.OK;
            }
            else
            {
                this.status = Status.FAIL;
            }
        }

        public override Control[] getEditControls()
        {
            return new Control[0];
        }

        public override string[] getErrors()
        {
            if (this.status == Status.FAIL)
            {
                return new string[] { "Bitlocker is not ready yet" };
            }
            else if (this.status == Status.NOTRUN)
            {
                return new string[] { "Bitlocker hasn't ran yet" };
            }

            return new string[0];
        }

        public override Status getStatus()
        {
            return this.status;
        }

        public override string ToString()
        {
            return "Check Bitlocker Status";
        }
    }
}
