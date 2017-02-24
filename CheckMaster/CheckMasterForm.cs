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

            // Bind ModuleManager's modules as DataSource to our modules list
            bindListBoxWithModules();
        }

        private void StatusList_DrawItem(object sender, DrawItemEventArgs e)
        {
            this.statusList_MeasureItem(e.Index);

            if (e.Index < 0 || sumTable.Count - 1 < e.Index)
                return;

            Console.WriteLine("Drawing item...");
            Console.WriteLine(((Module)((ListBox)sender).Items[e.Index]).getName());

            Color color = Color.Black;
            switch (((Module)statusList.Items[e.Index]).getStatus())
            {
                case Status.ERROR:
                    color = Color.Red;
                    break;
                case Status.FAIL:
                    color = Color.Orange;
                    break;
                case Status.NOTRUN:
                    color = Color.Gray;
                    break;
            }


            int positionY = 0;
            if (e.Index > 0)
            {
                positionY = sumTable[e.Index - 1];
            }


            // Background
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, positionY, 500, sumTable[e.Index]));

            // Text itself
            e.Graphics.DrawString(((Module)((ListBox)sender).Items[e.Index]).getName(), e.Font, new SolidBrush(color), 0, positionY, StringFormat.GenericDefault);
        }

        private void statusList_MeasureItem(int index)
        {
            if (index < 0)
                return;

            int amount = 0;
            if (sumTable.Count - 1 < index && index > 0)
            {
                amount += sumTable[index - 1];
            }

            int heightToAdd = 25 + (25 * moduleManager.modules[index].getErrors().Length);
            amount += heightToAdd;

            if (sumTable.Count - 1 < index)
            {
                sumTable.Add(amount);
            }
            else
            {
                sumTable[index] = amount;
            }
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

                    foreach (Module module in moduleManager.modules)
                    {
                        if (module.getStatus() != Status.NOTRUN)
                        {
                            howManyRan++;
                        }
                    }

                    this.howManyRanLabel.Text = "Ran " + howManyRan + "/" + this.moduleManager.modules.Count + " modules";

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
                };

                this.Invoke(mi);
            }
        }

        private void bindListBoxWithModules()
        {
            this.statusList.DataBindings.Clear();
            this.sumTable.Clear();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = moduleManager.modules;

            // this.statusList.DisplayMember = "ToString()";
            this.statusList.DataSource = bindingSource;
            this.statusList.DataBindings.Clear();
            //this.statusList.DataBindings.Add("name", bindingSource, "DisplayValue", true, DataSourceUpdateMode.OnPropertyChanged);
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

            this.bindListBoxWithModules();

            if(this.t.IsAlive == false)
                t.Start();
        }

        private void loadSettingsButton_Click(object sender, EventArgs e)
        {
            this.moduleManager = FileSaver.loadDialog();

            this.bindListBoxWithModules();
        }
    }
}
