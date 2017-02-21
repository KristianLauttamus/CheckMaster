using CheckMaster.Restrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.SuccessModules
{
    class EnterMBAM : MasterSuccessModule
    {
        private string readFromCSV;

        public EnterMBAM()
        {
            this.readFromCSV = "";
        }

        public override Control[] getEditControls()
        {
            List<Control> controls = new List<Control>();

            // ChangeNameLabel
            Label changeNameLabel = new Label();
            changeNameLabel.Location = new System.Drawing.Point(0, 0);
            changeNameLabel.Width = 50;
            changeNameLabel.Text = "Name:";
            //controls.Add(changeNameLabel);

            // ChangeName
            TextBox changeName = new TextBox();
            changeName.Location = new System.Drawing.Point(50,0);
            changeName.Width = 100;
            changeName.Multiline = false;
            //changeName.TextChanged += new EventHandler(NameChangedEvent);
            //controls.Add(changeName);

            // ReadFromCSVLabel
            Label ReadFromCSVLabel = new Label();
            ReadFromCSVLabel.Location = new System.Drawing.Point(0, 0);
            ReadFromCSVLabel.Width = 300;
            ReadFromCSVLabel.Text = "Read From CSV:";
            controls.Add(ReadFromCSVLabel);

            // ReadFromCSV
            TextBox readFromCSVCB = new TextBox();
            readFromCSVCB.Location = new System.Drawing.Point(0, 25);
            readFromCSVCB.Width = 250;
            readFromCSVCB.Text = this.readFromCSV;
            readFromCSVCB.TextChanged += new EventHandler(ReadFromCSV_TextChanged);
            controls.Add(readFromCSVCB);

            // ReadFromCSVDescription
            Label ReadFromCSVDescription = new Label();
            ReadFromCSVDescription.Location = new System.Drawing.Point(0, 50);
            ReadFromCSVDescription.Width = 450;
            ReadFromCSVDescription.Height = 250;
            ReadFromCSVDescription.ForeColor = System.Drawing.Color.Gray;
            ReadFromCSVDescription.Text = "Leave this to empty, to deactivate.\nEnter the file name and insert the file into the same directory with the application's .exe";
            controls.Add(ReadFromCSVDescription);

            Label RememberToRemoveTPM = new Label();
            RememberToRemoveTPM.Location = new System.Drawing.Point(0, 120);
            RememberToRemoveTPM.Width = 450;
            RememberToRemoveTPM.Height = 250;
            RememberToRemoveTPM.ForeColor = System.Drawing.Color.Gray;
            RememberToRemoveTPM.Text = "If you want it so that the Bitlocker password will be asked on boot,\nalso add the Remove TPM Success Module.";
            controls.Add(RememberToRemoveTPM);

            return controls.ToArray();
        }

        private void ReadFromCSV_TextChanged(object sender, EventArgs e)
        {
            this.readFromCSV = ((TextBox)sender).Text;
        }

        public override void run()
        {
            
        }

        public override string ToString()
        {
            return "Enter MBAM Passwords";
        }
    }
}
