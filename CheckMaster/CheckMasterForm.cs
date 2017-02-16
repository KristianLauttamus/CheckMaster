using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckMaster.Modules;

namespace CheckMaster
{
    public partial class CheckMasterForm : Form
    {
        Thread t;
        Serializer serializer;
        ModuleManager moduleManager;

        public CheckMasterForm()
        {
            moduleManager = new ModuleManager();
            serializer = new CheckMaster.Serializer();

            // Check if default settings file exists
            loadModuleManagerFromFile();

            // Initialize Modules
            moduleManager.init();

            InitializeComponent();
            
            t = new Thread(UpdateLoop);
        }
        
        /// <summary>
        /// Ease the way to start the update loop, since it needs to be stopped
        /// everytime new modules are being loaded
        /// </summary>
        private void startUpdateLoop()
        {
            t.Start();
        }

        /// <summary>
        /// Run update loop that handles specific actions on modules and updates
        /// the view
        /// </summary>
        private void UpdateLoop()
        {
            while (true)
            {
                // Run checks
                moduleManager.check();

                // Access UI elements
                MethodInvoker mi = delegate () {
                    if (moduleManager.failed())
                    {
                        this.okButton.Enabled = false;
                    }
                    else
                    {
                        this.okButton.Enabled = true;
                    }
                };

                this.Invoke(mi);
            }
        }

        /// <summary>
        /// Easier the way to stop the update loop
        /// </summary>
        private void stopUpdateLoop()
        {
            t.Abort();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditModulesForm editModulesForm = new CheckMaster.EditModulesForm();
            editModulesForm.TopMost = true;
            editModulesForm.FormClosing += new FormClosingEventHandler(editModulesForm_FormClosing);
            editModulesForm.Show();
            this.Enabled = false;
        }

        private void editModulesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadModuleManagerFromFile();
            this.Enabled = true;
        }

        private void computerInfo_Click(object sender, EventArgs e)
        {
            ComputerInfoForm computerInfoForm = new ComputerInfoForm();
            computerInfoForm.Show();
        }

        private void CheckMasterForm_Load(object sender, EventArgs e)
        {
            startUpdateLoop();
        }

        private void CheckMasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopUpdateLoop();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.moduleManager.failed() == false)
            {
                this.moduleManager.runSuccess();
                this.Close();
            }
        }

        private void loadModuleManagerFromFile()
        {
            // Reset to default if not found or empty
            if (
                Properties.Settings.Default["modulemanager"].ToString() == "" ||
                File.Exists(Properties.Settings.Default["modulemanager"].ToString()) == false
                )
            {
                Properties.Settings.Default["modulemanager"] = Application.StartupPath + "/default.modules";
            }

            // Check if found
            if (File.Exists(Properties.Settings.Default["modulemanager"].ToString()))
            {
                Console.WriteLine("Init ModuleManager");
                moduleManager = Serializer.DeSerializeObject<ModuleManager>(Properties.Settings.Default["modulemanager"].ToString());
            }
            else // If not, then create one and initialize it
            {
                Console.WriteLine("Create ModuleManager");
                moduleManager = new ModuleManager();
                Serializer.SerializeObject<ModuleManager>(moduleManager, Properties.Settings.Default["modulemanager"].ToString());
            }
        }

        private void loadSettingsButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openXMLFileDialog = new OpenFileDialog();

            openXMLFileDialog.InitialDirectory = Application.ExecutablePath;
            openXMLFileDialog.Filter = "Modules Files (*.modules)|*.modules";
            openXMLFileDialog.FilterIndex = 0;
            openXMLFileDialog.RestoreDirectory = true;

            if (openXMLFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.moduleManager = Serializer.DeSerializeObject<ModuleManager>(openXMLFileDialog.FileName);
            }
        }
    }
}
