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

        public override string ToString()
        {
            if (this.getName() != "")
            {
                return this.getName();
            }

            return "File Exists";
        }

        public Control[] getEditControls()
        {
            throw new NotImplementedException();
        }
    }
}
