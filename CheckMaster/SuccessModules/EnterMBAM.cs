using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.SuccessModules
{
    class EnterMBAM : SuccessModule
    {
        private bool readFromCSV;
        private string name;

        public EnterMBAM()
        {
            this.readFromCSV = false;
            this.name = "";
        }

        public Control[] getEditControls()
        {
            List<Control> controls = new List<Control>();

            // ChangeNameLabel
            Label changeNameLabel = new Label();
            changeNameLabel.Location = new System.Drawing.Point(0, 0);
            changeNameLabel.Width = 50;
            changeNameLabel.Text = "Name:";
            controls.Add(changeNameLabel);

            // ChangeName
            TextBox changeName = new TextBox();
            changeName.Location = new System.Drawing.Point(50,0);
            changeName.Width = 100;
            changeName.Multiline = false;
            changeName.TextChanged += new EventHandler(NameChangedEvent);
            controls.Add(changeName);

            // ReadFromCSV
            CheckBox readFromCSVCB = new CheckBox();
            readFromCSVCB.Location = new System.Drawing.Point(0, 25);
            readFromCSVCB.Width = 250;
            readFromCSVCB.Checked = readFromCSV;
            readFromCSVCB.CheckedChanged += new EventHandler(ReadFromCSVChanged);
            readFromCSVCB.Text = "Read From Excel";
            controls.Add(readFromCSVCB);

            return controls.ToArray();
        }

        private void ReadFromCSVChanged(object sender, EventArgs e)
        {
            this.readFromCSV = ((CheckBox)sender).Checked;
        }

        private void NameChangedEvent(object sender, EventArgs a)
        {
            this.name = ((TextBox)sender).Text;
        }

        public string getName()
        {
            return this.name;
        }

        public override string ToString()
        {
            if (this.getName() != "")
            {
                return this.getName();
            }

            return "Enter MBAM Passwords";
        }
    }
}
