using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckMaster.Restrictions;

namespace CheckMaster.Modules
{
    class CheckBitlockerStatus : Module
    {
        private Status status;
        private List<Restriction> restrictions;

        public CheckBitlockerStatus()
        {
            this.restrictions = new List<Restriction>();
        }

        public void init()
        {
            this.status = Status.NOTRUN;
        }

        public void check()
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

        public Control[] getEditControls()
        {
            return new Control[0];
        }

        public string[] getErrors()
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

        public Status getStatus()
        {
            return this.status;
        }

        #region Restrictions
        public void addRestriction(Restriction restriction)
        {
            this.restrictions.Add(restriction);
        }

        public void initRestrictions()
        {
            foreach (Restriction restriction in restrictions)
            {
                restriction.init();
            }
        }

        public List<Restriction> getRestrictions()
        {
            return this.restrictions;
        }

        public bool isRestricted()
        {
            foreach (Restriction restriction in restrictions)
            {
                if (restriction.approved() == false)
                {
                    return true;
                }
            }

            return false;
        }

        public void removeRestriction(int index)
        {
            this.restrictions.RemoveAt(index);
        }
        #endregion
    }
}
