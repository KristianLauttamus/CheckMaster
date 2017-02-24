using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.FileDialogs
{
    public partial class LoadFileForm : Form
    {
        public bool load;
        public string file;

        public LoadFileForm(string location, string suffix)
        {
            load = false;

            InitializeComponent();

            loadFilesToChooseFrom(location, suffix);
        }

        private void loadFilesToChooseFrom(string location, string suffix)
        {
            this.filesComboBox.Items.Clear();

            string[] files = Directory.EnumerateFiles(location, "*", SearchOption.AllDirectories).Select(Path.GetFileName).ToArray();
            List<string> filesToLoad = new List<string>();

            foreach(string file in files)
            {
                if (file.EndsWith(suffix))
                {
                    filesToLoad.Add(file);
                }
            }

            this.filesComboBox.Items.AddRange(filesToLoad.ToArray());
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            load = true;

            this.Close();
        }

        private void filesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex >= 0)
            {
                this.file = ((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex].ToString();
                this.loadButton.Enabled = true;
            }
            else
            {
                this.loadButton.Enabled = false;
            }
        }
    }
}
