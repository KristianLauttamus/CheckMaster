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
        private string FILE_PATH;
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

            // Full Filepath
            Label FullFilepath = new Label();
            FullFilepath.Location = new System.Drawing.Point(0,0);
            FullFilepath.Width = 400;
            FullFilepath.Text = "Full Filepath (Example: C:/Program Files/Office/EXCEL.exe)";
            controls.Add(FullFilepath);

            // Full Filepath Textbox
            TextBox FullFilepathTextBox = new TextBox();
            FullFilepathTextBox.Location = new System.Drawing.Point(0,25);
            FullFilepathTextBox.Width = 200;
            FullFilepathTextBox.Multiline = false;
            FullFilepathTextBox.TextChanged += FullFilepathTextBox_TextChanged;
            FullFilepathTextBox.Text = this.FILE_PATH;
            controls.Add(FullFilepathTextBox);

            return controls.ToArray();
        }

        private void FullFilepathTextBox_TextChanged(object sender, EventArgs e)
        {
            this.FILE_PATH = ((TextBox)sender).Text;
        }

        public override string ToString()
        {
            return "File Exists";
        }
    }
}
