using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CheckMaster
{
    [Serializable]
    class ModuleManager
    {
        private List<Module> modules;
        private bool hasErrors;

        public ModuleManager()
        {
            this.modules = new List<Module>();
            this.hasErrors = false;
        }

        public void init()
        {
            foreach (Module module in modules)
            {
                module.init();
            }
        }

        public void check()
        {
            foreach (Module module in modules)
            {
                module.check();

                if (module.getStatus() == Status.ERROR || module.getStatus() == Status.FAIL)
                {
                    this.hasErrors = true;
                }
            }
        }

        public bool failed()
        {
            return this.hasErrors;
        }
    }
}
