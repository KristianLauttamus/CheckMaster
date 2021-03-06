﻿using CheckMaster.Restrictions;
using CheckMaster.SuccessModules;
using System;
using System.Collections.Generic;
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
    public partial class RestrictionEditingForm : Form
    {
        private Modules.Module module;
        private SuccessModule successModule;

        public RestrictionEditingForm(Modules.Module module)
        {
            this.module = module;

            init();
        }

        public RestrictionEditingForm(SuccessModule successModule)
        {
            this.successModule = successModule;

            init();
        }

        private void init()
        {
            InitializeComponent();

            if (module != null)
            {
                this.moduleLabel.Text = module.ToString();
                this.restrictionsListBox.Items.AddRange(module.getRestrictions().ToArray());
            }
            else if (successModule != null)
            {
                this.moduleLabel.Text = successModule.ToString();
                this.restrictionsListBox.Items.AddRange(successModule.getRestrictions().ToArray());
            }

            loadRestrictions();
        }

        private void loadRestrictions()
        {
            string @namespace = "CheckMaster.Restrictions";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @namespace
                    select t;
            q.ToList().ForEach(m => {
                Restriction instance = (Restriction)Activator.CreateInstance(m);
                this.restrictionsComboBox.Items.Add(instance);
            }
            );
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void restrictionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex < 0)
                return;

            Restriction restriction = (Restriction)((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex];
            this.restrictionsListBox.Items.Add(restriction);
            this.restrictionsComboBox.SelectedIndex = -1;
        }

        private void restrictionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editPanel.Controls.Clear();

            if (((ListBox)sender).SelectedIndex > -1)
                this.editPanel.Controls.AddRange(((Restriction)((ListBox)sender).Items[((ListBox)sender).SelectedIndex]).getEditControls());
        }

        private void save()
        {
            Restriction[] restrictions = new Restriction[this.restrictionsListBox.Items.Count];

            for (int i = 0; i < restrictions.Length; i++)
            {
                restrictions[i] = (Restriction)this.restrictionsListBox.Items[i];
            }

            if (this.module != null)
            {
                this.module.clearRestrictions();
                this.module.addRestrictions(restrictions);
            }
            else if (this.successModule != null)
            {
                this.successModule.clearRestrictions();
                this.successModule.addRestrictions(restrictions);
            }
        }

        private void RestrictionEditingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.save();
        }
    }
}
