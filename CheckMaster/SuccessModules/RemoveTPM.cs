using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckMaster.Restrictions;

namespace CheckMaster.SuccessModules
{
    class RemoveTPM : SuccessModule
    {
        public RemoveTPM()
        {
            this.restrictions = new List<Restriction>();
        }

        public Control[] getEditControls()
        {
            return new Control[0];
        }

        public void run()
        {
            WMIController.removeTPM(WMIController.getDeviceID());
        }

        #region Restrictions
        private List<Restriction> restrictions;

        public void addRestriction(Restriction restriction)
        {
            throw new NotImplementedException();
        }

        public List<Restriction> getRestrictions()
        {
            throw new NotImplementedException();
        }

        public void initRestrictions()
        {
            throw new NotImplementedException();
        }

        public bool isRestricted()
        {
            throw new NotImplementedException();
        }

        public void removeRestriction(int index)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
