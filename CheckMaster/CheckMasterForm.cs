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

        private List<int> sumTable;

        public CheckMasterForm()
        {
            sumTable = new List<int>();
            t = new Thread(UpdateLoop);

            InitializeComponent();

            moduleManager = new ModuleManager();
            serializer = new CheckMaster.Serializer();

            // Check if default settings file exists
            // Also initializes ModuleManager
            loadModuleManagerFromFile();
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
                try
                {
                    moduleManager.check();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                // Access UI elements
                MethodInvoker mi = delegate () {
                    int howManyRan = 0;

                    foreach (Module module in moduleManager.getUnrestrictedModules())
                    {
                        if (module.getStatus() != Status.NOTRUN)
                        {
                            howManyRan++;
                        }
                    }

                    this.howManyRanLabel.Text = "Ran " + howManyRan + "/" + this.moduleManager.getUnrestrictedModules().Count + " modules";

                    if (moduleManager.failed())
                    {
                        this.okButton.Enabled = false;
                    }
                    else
                    {
                        this.okButton.Enabled = true;
                    }

                    // Update current file -label
                    this.currentFileLabel.Text = Properties.Settings.Default["modulemanager"].ToString();

                    this.updateModuleLabels();
                };

                this.Invoke(mi);
            }
        }

        private void updateModuleLabels()
        {
            // Check if no modules
            if (this.moduleManager.getUnrestrictedModules().Count == 0)
            {
                return;
            }

            // Create
            if (this.modulesLabelPanel.Controls.Count == 0 || this.modulesLabelPanel.Controls.Count != this.moduleManager.getUnrestrictedModules().Count) {
                this.modulesLabelPanel.Controls.Clear();

                // Keep the current height
                int currentHeight = 0;

                foreach (Module module in this.moduleManager.getUnrestrictedModules())
                {
                    Label label = new Label();
                    label.Text = module.getName();
                    label.Width = 400;
                    label.Height = calculateLabelheight(module);
                    label.Location = new Point(0, currentHeight);
                    label.ForeColor = ModuleColorByStatus(module);
                    this.modulesLabelPanel.Controls.Add(label);

                    currentHeight += label.Height;
                }
            }
            else
            {
                int controlIndex = 0;
                foreach (Module module in this.moduleManager.getUnrestrictedModules())
                {
                    if (this.modulesLabelPanel.Controls[controlIndex].Text != module.getName())
                    {
                        this.modulesLabelPanel.Controls[controlIndex].Text = module.getName();
                        this.modulesLabelPanel.Controls[controlIndex].Height = calculateLabelheight(module);
                        this.modulesLabelPanel.Controls[controlIndex].ForeColor = ModuleColorByStatus(module);
                    }
                    controlIndex++;
                }
            }
        }

        private Color ModuleColorByStatus(Module module)
        {
            switch (module.getStatus())
            {
                case Status.ERROR:
                    return Color.Red;
                case Status.FAIL:
                    return Color.DarkRed;
                case Status.OK:
                    return Color.Green;
                default:
                    return Color.Gray;
            }
        }

        private int calculateLabelheight(Module module)
        {
            // Check errors and update labelHeight
            int labelHeight = 25;
            foreach (string error in module.getErrors())
            {
                labelHeight += 25;
            }

            return labelHeight;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditModulesForm editModulesForm = new EditModulesForm(moduleManager);
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
            computerInfoForm.TopMost = true;
            computerInfoForm.Show();
        }

        private void CheckMasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
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
                Properties.Settings.Default["modulemanager"] = "default.modules";
            }

            // Check if found
            if (File.Exists(Properties.Settings.Default["modulemanager"].ToString()))
            {
                Console.WriteLine("Init ModuleManager");
                moduleManager = FileSaver.load();
            }
            else // If not, then create one and initialize it
            {
                Console.WriteLine("Create ModuleManager");
                moduleManager = new ModuleManager();
                Serializer.SerializeObject<ModuleManager>(moduleManager, Properties.Settings.Default["modulemanager"].ToString());
            }

            this.moduleManager.init();
            this.modulesLabelPanel.Controls.Clear();

            if(this.t.IsAlive == false)
                t.Start();
        }

        private void loadSettingsButton_Click(object sender, EventArgs e)
        {
            this.moduleManager = FileSaver.loadDialog();
        }
    }
}
