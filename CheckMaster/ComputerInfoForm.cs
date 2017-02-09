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
    public partial class ComputerInfoForm : Form
    {
        public ComputerInfoForm()
        {
            InitializeComponent();

            Dictionary<string, string> computerInfo = WMIController.getComputerSystemInfo();

            foreach(string key in computerInfo.Keys)
            {
                this.ComputerInfoList.Items.Add(key + " = " + computerInfo[key]);
            }

            this.linkToCreator.Links.Add(0,0,"http://github.com/KristianLauttamus");
        }

        private void linkToCreator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
    }
}
