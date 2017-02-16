using CheckMaster.Modules;
using CheckMaster.Restrictions;
using CheckMaster.SuccessModules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster
{
    public partial class EditModulesForm : Form
    {
        Dictionary<Modules.Module, List<Restriction>> modules;
        Dictionary<SuccessModule, List<Restriction>> successModules;

        public bool changed;

        public EditModulesForm()
        {
            modules = new Dictionary<Modules.Module, List<Restriction>>();
            successModules = new Dictionary<SuccessModule, List<Restriction>>();
            changed = false;

            InitializeComponent();

            // Get all Modules
            loadModules();

            // Get all SuccessModules
            loadSuccessModules();
        }

        public Dictionary<Modules.Module, List<Restriction>> GetModules()
        {
            return this.modules;
        }

        public Dictionary<SuccessModule, List<Restriction>> GetSuccessModules()
        {
            return this.successModules;
        }

        #region Modules
        private void loadModules()
        {
            string @namespace = "CheckMaster.Modules";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @namespace
                    select t;
            q.ToList().ForEach(m => {
                Modules.Module instance = (Modules.Module)Activator.CreateInstance(m);
                this.modulesSelection.Items.Add(instance);
            }
            );
        }

        private void modulesSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modulesSelection.SelectedIndex == -1)
            {
                return;
            }

            Modules.Module m = (Modules.Module)Activator.CreateInstance(modulesSelection.Items[modulesSelection.SelectedIndex].GetType());

            addedModulesList.Items.Add(m);

            addedModulesList.SelectedIndex = addedModulesList.Items.Count - 1;
            modulesSelection.SelectedIndex = -1;
            this.changed = true;
        }
        private void loadModule(Modules.Module m)
        {
            this.clearEditPanel();
            this.editPanel.Controls.AddRange(m.getEditControls());
        }

        private void addedModulesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addedModulesList.SelectedIndex == -1)
            {
                clearEditPanel();
                this.removeModuleButton.Enabled = false;
                this.editModuleRestrictions.Enabled = false;
                return;
            }

            this.addedSuccessModulesList.SelectedIndex = -1;

            Modules.Module m = (Modules.Module)addedModulesList.Items[addedModulesList.SelectedIndex];
            loadModule(m);
            this.removeModuleButton.Enabled = true;
            this.editModuleRestrictions.Enabled = true;
            this.changed = true;
        }

        private void removeModuleButton_Click(object sender, EventArgs e)
        {
            if (addedModulesList.SelectedIndex > -1)
            {
                addedModulesList.Items.RemoveAt(addedModulesList.SelectedIndex);
                addedModulesList.SelectedIndex = -1;
                this.changed = true;
            }
        }
        #endregion

        #region Success Modules
        private void loadSuccessModules()
        {
            string @namespace = "CheckMaster.SuccessModules";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @namespace
                    select t;
            q.ToList().ForEach(sm => {
                SuccessModule instance = (SuccessModule)Activator.CreateInstance(sm);
                this.successModulesSelection.Items.Add(instance);
            });
        }

        private void successModulesSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (successModulesSelection.SelectedIndex == -1)
            {
                return;
            }

            SuccessModule sm = (SuccessModule)Activator.CreateInstance(successModulesSelection.Items[successModulesSelection.SelectedIndex].GetType());

            addedSuccessModulesList.Items.Add(sm);

            addedSuccessModulesList.SelectedIndex = addedSuccessModulesList.Items.Count - 1;
            successModulesSelection.SelectedIndex = -1;
            this.changed = true;
        }
        private void loadSuccessModule(SuccessModule sm)
        {
            this.clearEditPanel();
            this.editPanel.Controls.AddRange(sm.getEditControls());
        }

        private void addedSuccessModulesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addedSuccessModulesList.SelectedIndex == -1)
            {
                clearEditPanel();
                this.removeSuccessModuleButton.Enabled = false;
                this.editSuccessModuleRestrictions.Enabled = false;
                return;
            }

            this.addedModulesList.SelectedIndex = -1;

            SuccessModule sm = (SuccessModule)addedSuccessModulesList.Items[addedSuccessModulesList.SelectedIndex];
            loadSuccessModule(sm);
            this.removeSuccessModuleButton.Enabled = true;
            this.editSuccessModuleRestrictions.Enabled = true;
            this.changed = true;
        }

        private void removeSuccessModuleButton_Click(object sender, EventArgs e)
        {
            if (addedSuccessModulesList.SelectedIndex > -1)
            {
                addedSuccessModulesList.Items.RemoveAt(addedSuccessModulesList.SelectedIndex);
                addedSuccessModulesList.SelectedIndex = -1;
                this.changed = true;
            }
        }
        #endregion

        private void clearEditPanel()
        {
            this.editPanel.Controls.Clear();
        }

        private void EditModulesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.changed && MessageBox.Show("Are you sure you want to exit editing without saving?",
                       "Humans make mistakes",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void editSuccessModuleRestrictions_Click(object sender, EventArgs e)
        {
            if (this.addedSuccessModulesList.SelectedIndex >= 0)
            {
                SuccessModule sm = (SuccessModule)addedSuccessModulesList.Items[addedSuccessModulesList.SelectedIndex];
                RestrictionEditingForm restrictionEditingForm = new RestrictionEditingForm(sm);
                restrictionEditingForm.Show();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.save();

            this.changed = false;
            this.Close();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Modules File|*.modules";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                Properties.Settings.Default["modulemanager"] = saveFileDialog.FileName;
                this.save();
            }
            else
            {
                MessageBox.Show("Error: Could not save chosen file");
            }
        }

        /// <summary>
        /// Create a temp ModuleManager and save it to the path given in the settings
        /// </summary>
        private void save()
        {
            string path = Properties.Settings.Default["modulemanager"].ToString();

            ModuleManager moduleManager = new ModuleManager();
            moduleManager.modules = this.modules;
            moduleManager.successModules = this.successModules;

            Serializer.SerializeObject<ModuleManager>(moduleManager, path);

            this.changed = false;
        }
    }
}
