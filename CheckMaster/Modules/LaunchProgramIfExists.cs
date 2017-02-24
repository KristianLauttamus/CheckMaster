using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckMaster.Restrictions;
using System.IO;
using System.Diagnostics;

namespace CheckMaster.Modules
{
    [Serializable]
    class LaunchProgramIfExists : MasterModule
    {
        private Status status;
        private string filepath;

        public LaunchProgramIfExists()
        {
            this.status = Status.NOTRUN;
        }

        public override void init()
        {
            if (File.Exists(this.filepath))
            {
                try
                {
                    Process.Start(this.filepath);
                    this.status = Status.OK;
                }
                catch
                {
                    this.status = Status.ERROR;
                }
            }
            else
            {
                this.status = Status.FAIL;
            }
        }

        public override void check()
        {
            return;
        }
        
        public override string[] getErrors()
        {
            if (this.status == Status.FAIL)
            {
                return new string[] { "File not found" };
            }
            else if (this.status == Status.ERROR)
            {
                return new string[] { "Could not open file" };
            }

            return new string[] { "Not ran yet" };
        }

        public override Status getStatus()
        {
            return this.status;
        }

        public override Control[] getEditControls()
        {
            List<Control> controls = new List<Control>();

            // Label
            Label filepathLabel = new Label();
            filepathLabel.Text = "Filepath";
            filepathLabel.Location = new System.Drawing.Point(0,0);
            filepathLabel.Width = 200;
            controls.Add(filepathLabel);

            // TextBox
            TextBox filepathTextbox = new TextBox();
            filepathTextbox.Width = 250;
            filepathTextbox.Location = new System.Drawing.Point(0,25);
            filepathTextbox.TextChanged += new EventHandler(filepathTextbox_TextChanged);
            filepathTextbox.Text = this.filepath;
            controls.Add(filepathTextbox);

            return controls.ToArray();
        }

        private void filepathTextbox_TextChanged(object sender, EventArgs e)
        {
            this.filepath = ((TextBox)sender).Text;
        }

        public override string ToString()
        {
            return "Launch program if it exists";
        }
    }
}
