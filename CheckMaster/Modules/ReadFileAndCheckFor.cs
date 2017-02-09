using CheckMaster.Restrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.Modules
{
    [Serializable]
    class ReadFileAndCheckFor : Module
    {
        public String FILE_PATH;

        public ReadFileAndCheckFor()
        {
            this.FILE_PATH = "";
        }

        public void check()
        {
            throw new NotImplementedException();
        }

        public Control[] getEditControls()
        {
            throw new NotImplementedException();
        }

        public string[] getErrors()
        {
            throw new NotImplementedException();
        }

        public string getName()
        {
            return "";
        }

        public Status getStatus()
        {
            throw new NotImplementedException();
        }

        public void init()
        {
            throw new NotImplementedException();
        }

        #region Restrictions
        private List<Restriction> restrictions = new List<Restriction>();

        public void addRestriction(Restriction restriction)
        {
            this.restrictions.Add(restriction);
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
            return "File Exists";
        }
    }
}
