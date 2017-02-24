using CheckMaster.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckMaster.Restrictions;
using System.Windows.Forms;

namespace CheckMaster.Modules
{
    [Serializable]
    class MasterModule : Module
    {
        private static int lastID = 0;
        private int ID = 0;
        private string DisplayValue = "";
        private List<Restriction> restrictions = new List<Restriction>();

        public MasterModule()
        {
            this.ID = ++lastID;
        }

        public virtual void init()
        {
            return;
        }

        public virtual void check()
        {
            return;
        }

        public virtual Status getStatus()
        {
            return Status.NOTRUN;
        }

        public virtual string[] getErrors()
        {
            return new string[0];
        }

        public virtual Control[] getEditControls()
        {
            return new Control[0];
        }

        public virtual void updateDisplayValue()
        {
            String display = "[" + this.getStatus() + "] " + this.ToString();

            foreach(string error in this.getErrors())
            {
                display += "\n - " + error;
            }

            this.DisplayValue = display;
        }

        public virtual string getName()
        {
            this.updateDisplayValue();
            return this.DisplayValue;
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
