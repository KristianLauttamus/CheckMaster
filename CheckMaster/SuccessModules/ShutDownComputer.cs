using CheckMaster.Restrictions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.SuccessModules
{
    [Serializable]
    class ShutDownComputer : MasterSuccessModule
    {
        private int seconds;
        private string name;
        private bool force;

        public ShutDownComputer()
        {
            this.seconds = 0;
            this.name = "";
            this.force = false;
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
            changeName.Location = new System.Drawing.Point(50, 0);
            changeName.Width = 100;
            changeName.Multiline = false;
            changeName.TextChanged += new EventHandler(NameChangedEvent);
            //controls.Add(changeName);

            // Force Shutdown
            CheckBox forceShutdown = new CheckBox();
            forceShutdown.Location = new System.Drawing.Point(0, 25);
            forceShutdown.Width = 250;
            forceShutdown.Checked = this.force;
            forceShutdown.CheckedChanged += new EventHandler(ForceChanged);
            forceShutdown.Text = "Force Shutdown";
            controls.Add(forceShutdown);

            //
            Label secondsLabel = new Label();
            secondsLabel.Location = new System.Drawing.Point(0, 75);
            secondsLabel.Width = 300;
            secondsLabel.Text = "Seconds before shutdown:";
            controls.Add(secondsLabel);

            // SecondsNumeric
            NumericUpDown secondsNumeric = new NumericUpDown();
            secondsNumeric.Location = new System.Drawing.Point(0, 100);
            secondsNumeric.Width = 250;
            secondsNumeric.Minimum = 0;
            secondsNumeric.ValueChanged += new EventHandler(SecondsChanged);
            controls.Add(secondsNumeric);

            return controls.ToArray();
        }

        private void SecondsChanged(object sender, EventArgs e)
        {
            this.seconds = (int)((NumericUpDown)sender).Value;
        }

        private void ForceChanged(object sender, EventArgs e)
        {
            this.force = ((CheckBox)sender).Checked;
        }

        private void NameChangedEvent(object sender, EventArgs e)
        {
            this.name = ((TextBox)sender).Text;
        }

        public override void run()
        {
            string forceOption = " ";
            if (this.force)
            {
                forceOption = "/f ";
            }
            var psi = new ProcessStartInfo("shutdown", "/s "+forceOption+"/t " + this.seconds);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        public override string ToString()
        {
            return "Shutdown Computer";
        }
    }
}
