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

        public override string ToString()
        {
            if (this.getName() != "")
            {
                return this.getName();
            }

            return "Read File Lines";
        }
    }
}
