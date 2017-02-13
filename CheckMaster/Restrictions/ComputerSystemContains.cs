using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.Restrictions
{
    class ComputerSystemContains : Restriction
    {
        public string key;
        public string value;
        private Dictionary<string, string> computersystem;

        public ComputerSystemContains()
        {
            this.key = "";
            this.value = "";
            this.computersystem = new Dictionary<string, string>();
        }

        public bool approved()
        {
            return this.computersystem.ContainsKey(key) && this.computersystem[key].Contains(value);
        }

        public Control[] getEditControls()
        {
            List<Control> controls = new List<Control>();

            // KeyTextBox
            TextBox KeyTextBox = new TextBox();
            KeyTextBox.Width = 200;
            KeyTextBox.TextChanged += new EventHandler(KeyTextBox_TextChanged);
            controls.Add(KeyTextBox);

            // ValueTextBox
            TextBox ValueTextBox = new TextBox();
            ValueTextBox.Width = 200;
            ValueTextBox.TextChanged += new EventHandler(ValueTextBox_TextChanged);
            controls.Add(ValueTextBox);

            return controls.ToArray();
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            this.value = ((TextBox)sender).Text;
        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            this.key = ((TextBox)sender).Text;
        }

        public void init()
        {
            computersystem = WMIController.getComputerSystemInfo();
        }
    }
}
