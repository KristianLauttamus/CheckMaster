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
    class CheckFileExisting : MasterModule
    {
        private String FILE_PATH;
        private Status status;

        public CheckFileExisting()
        {
            this.FILE_PATH = "";
            this.status = Status.NOTRUN;
        }

        public override void init()
        {
            status = Status.NOTRUN;
        }

        public override void check()
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

        public override Status getStatus()
        {
            return status;
        }

        public override string[] getErrors()
        {
            if (status == Status.FAIL)
            {
                return new string[]{ "Tiedostoa ei löytynyt" };
            }

            return new string[0];
        }

        public override Control[] getEditControls()
        {
            List<Control> controls = new List<Control>();

            return controls.ToArray();
        }

        public override string ToString()
        {
            return "File Exists";
        }
    }
}
