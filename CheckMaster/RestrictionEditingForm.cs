using CheckMaster.SuccessModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            InitializeComponent();

            this.moduleLabel.Text = module.ToString();
        }

        public RestrictionEditingForm(SuccessModule successModule)
        {
            this.successModule = successModule;
            InitializeComponent();

            this.moduleLabel.Text = successModule.ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
