﻿using System;
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
        String FILE_PATH = Application.StartupPath + "/default.settings";

        public CheckMasterForm()
        {
            serializer = new CheckMaster.Serializer();

            // Check if default settings file exists
            if (File.Exists(FILE_PATH))
            {
                moduleManager = serializer.DeSerializeObject<ModuleManager>(FILE_PATH);
            }
            else // If not, then create one and initialize it
            {
                moduleManager = new ModuleManager();
                serializer.SerializeObject<ModuleManager>(moduleManager, FILE_PATH);
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            EditModulesForm editModulesForm = new CheckMaster.EditModulesForm();
            editModulesForm.Show();
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
    }
}