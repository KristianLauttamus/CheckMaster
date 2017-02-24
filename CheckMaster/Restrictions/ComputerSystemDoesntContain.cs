using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.Restrictions
{
    [Serializable]
    class ComputerSystemDoesntContain : Restriction
    {
        public string key;
        public string value;
        private Dictionary<string, string> computersystem;

        public ComputerSystemDoesntContain()
        {
            this.key = "";
            this.value = "";
            this.computersystem = new Dictionary<string, string>();
        }

        public bool approved()
        {
            return this.computersystem.ContainsKey(key) && this.computersystem[key].Contains(value) == false;
        }

        public Control[] getEditControls()
        {
            List<Control> controls = new List<Control>();

            // ValueLabel
            Label KeyLabel = new Label();
            KeyLabel.Location = new System.Drawing.Point(0, 0);
            KeyLabel.Height = 25;
            KeyLabel.Width = 200;
            KeyLabel.Text = "Key";
            controls.Add(KeyLabel);

            // KeyTextBox
            ComboBox KeyComboBox = new ComboBox();
            KeyComboBox.Width = 200;
            KeyComboBox.Location = new System.Drawing.Point(0, 25);
            KeyComboBox.SelectedValueChanged += new EventHandler(KeyComboBox_SelectedValueChanged);
            KeyComboBox.Items.AddRange(WMIController.getComputerSystemInfoOptions());
            KeyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            controls.Add(KeyComboBox);

            // ValueLabel
            Label ValueLabel = new Label();
            ValueLabel.Location = new System.Drawing.Point(0, 50);
            ValueLabel.Height = 25;
            ValueLabel.Width = 200;
            ValueLabel.Text = "Value";
            controls.Add(ValueLabel);

            // ValueTextBox
            TextBox ValueTextBox = new TextBox();
            ValueTextBox.Width = 200;
            ValueTextBox.Location = new System.Drawing.Point(0, 75);
            ValueTextBox.TextChanged += new EventHandler(ValueTextBox_TextChanged);
            controls.Add(ValueTextBox);
            
            // ComputerSystemInfo
            Button computerInfo = new Button();
            computerInfo.Location = new System.Drawing.Point(0, 200);
            computerInfo.Size = new System.Drawing.Size(90, 23);
            computerInfo.Text = "Computer info";
            computerInfo.UseVisualStyleBackColor = true;
            computerInfo.Click += new System.EventHandler(computerInfo_Click);
            controls.Add(computerInfo);

            return controls.ToArray();
        }

        private void computerInfo_Click(object sender, EventArgs e)
        {
            ComputerInfoForm computerInfoForm = new ComputerInfoForm();
            computerInfoForm.Show();
        }

        private void KeyComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.key = ((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex].ToString();
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            this.value = ((TextBox)sender).Text;
        }

        public void init()
        {
            computersystem = WMIController.getComputerSystemInfo();
        }

        public override string ToString()
        {
            return "If ComputerSystem doesn't contain";
        }
    }
}
