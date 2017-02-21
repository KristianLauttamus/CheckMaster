using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckMaster.Restrictions;

namespace CheckMaster.SuccessModules
{
    class RemoveTPM : MasterSuccessModule
    {
        public override Control[] getEditControls()
        {
            return new Control[0];
        }

        public override void run()
        {
            WMIController.removeTPM(WMIController.getDeviceID());
        }

        public override string ToString()
        {
            return "Remove TPM";
        }
    }
}
