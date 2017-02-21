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
    public partial class SaveFileForm : Form
    {
        public string file;
        public bool save;

        public SaveFileForm(string path, string suffix)
        {
            this.save = false;

            InitializeComponent();

            loadFilesToChooseFrom(path,suffix);
        }

        private void loadFilesToChooseFrom(string location, string suffix)
        {
            this.fileComboBox.Items.Clear();

            string[] files = Directory.EnumerateFiles(location, "*", SearchOption.AllDirectories).Select(Path.GetFileName).ToArray();
            List<string> filesToLoad = new List<string>();

            foreach (string file in files)
            {
                if (file.EndsWith(suffix))
                {
                    filesToLoad.Add(file.Substring(0,file.IndexOf(suffix)));
                }
            }

            this.fileComboBox.Items.AddRange(filesToLoad.ToArray());
        }

        private void fileComboBox_TextChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text != "")
            {
                this.saveButton.Enabled = true;
                this.file = ((ComboBox)sender).Text;
            }
            else
            {
                this.saveButton.Enabled = false;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.save = true;
            this.Close();
        }
    }
}
