using CheckMaster.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMaster.Restrictions;
using System.Windows.Forms;
using CheckMaster.SuccessModules;

namespace CheckMaster.SuccessModules
{
    [Serializable]
    class MasterSuccessModule : SuccessModule
    {
        private List<Restriction> restrictions = new List<Restriction>();

        public virtual void run()
        {
            return;
        }

        public virtual Control[] getEditControls()
        {
            return new Control[0];
        }

        #region Restrictions
        public void addRestriction(Restriction restriction)
        {
            this.restrictions.Add(restriction);
        }
        
        public void addRestrictions(Restriction[] restrictions)
        {
            this.restrictions.AddRange(restrictions);
        }

        public void clearRestrictions()
        {
            this.restrictions.Clear();
        }

        public void removeRestriction(int index)
        {
            this.restrictions.RemoveAt(index);
        }

        public void initRestrictions()
        {
            foreach (Restriction restriction in this.restrictions)
            {
                restriction.init();
            }
        }

        public bool isRestricted()
        {
            foreach (Restriction restriction in this.restrictions)
            {
                if (restriction.approved() == false)
                    return true;
            }

            return false;
        }

        public List<Restriction> getRestrictions()
        {
            return this.restrictions;
        }
        #endregion

        public override string ToString()
        {
            return "["+this.restrictions.Count+"]";
        }
    }
}
