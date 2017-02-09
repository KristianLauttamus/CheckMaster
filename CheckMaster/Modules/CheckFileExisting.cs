using CheckMaster.Restrictions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.Modules
{
    [Serializable]
    class CheckFileExisting : Module
    {
        private String FILE_PATH;
        private Status status;
        private String name;

        public CheckFileExisting()
        {
            this.FILE_PATH = "";
            this.status = Status.NOTRUN;
            this.name = "";
        }

        public string getName()
        {
            return this.name;
        }

        public void init()
        {
            status = Status.NOTRUN;
        }

        public void check()
        {
            if (File.Exists(FILE_PATH))
            {
                status = Status.OK;
            }
            else
            {
                status = Status.FAIL;
            }
        }

        public Status getStatus()
        {
            return status;
        }

        public string[] getErrors()
        {
            if (status == Status.FAIL)
            {
                return new string[]{ "Tiedostoa ei löytynyt" };
            }

            return new string[0];
        }

        public Control[] getEditControls()
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
