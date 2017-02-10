using CheckMaster.Modules;
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
        List<Modules.Module> modules;
        List<SuccessModule> successModules;

        public EditModulesForm()
        {
            modules = new List<Modules.Module>();
            successModules = new List<SuccessModule>();
            
            InitializeComponent();

            // Get all Modules
            loadModules();

            // Get all SuccessModules
            loadSuccessModules();
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
                return;
            }

            Modules.Module m = (Modules.Module)addedModulesList.Items[addedModulesList.SelectedIndex];
            loadModule(m);
            this.removeModuleButton.Enabled = true;
        }

        private void removeModuleButton_Click(object sender, EventArgs e)
        {
            if (addedModulesList.SelectedIndex > -1)
            {
                addedModulesList.Items.RemoveAt(addedModulesList.SelectedIndex);
                addedModulesList.SelectedIndex = -1;
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
                }
            );
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
                return;
            }

            SuccessModule sm = (SuccessModule)addedSuccessModulesList.Items[addedSuccessModulesList.SelectedIndex];
            loadSuccessModule(sm);
            this.removeSuccessModuleButton.Enabled = true;
        }

        private void removeSuccessModuleButton_Click(object sender, EventArgs e)
        {
            if (addedSuccessModulesList.SelectedIndex > -1)
            {
                addedSuccessModulesList.Items.RemoveAt(addedSuccessModulesList.SelectedIndex);
                addedSuccessModulesList.SelectedIndex = -1;
            }
        }
        #endregion

        private void clearEditPanel()
        {
            this.editPanel.Controls.Clear();
        }
    }
}
