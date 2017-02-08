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

namespace CheckMaster
{
    public partial class CheckMasterForm : Form
    {
        Thread t;
        Serializer serializer;
        ModuleManager moduleManager;
        String FILE_PATH = Application.StartupPath + "/default.settings";
        ObservableCollection<Module> statuses; 

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
    }
}
