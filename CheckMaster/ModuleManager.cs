using CheckMaster.Modules;
using CheckMaster.Restrictions;
using CheckMaster.SuccessModules;
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
    public class ModuleManager
    {
        public List<Module> modules;
        public List<SuccessModule> successModules;

        public ModuleManager()
        {
            this.modules = new List<Module>();
            this.successModules = new List<SuccessModule>();
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
                module.updateDisplayValue();
            }
        }

        public bool failed()
        {
            foreach (Module module in modules)
            {
                if (module.getStatus() == Status.ERROR || module.getStatus() == Status.FAIL)
                {
                    return true;
                }
            }

            return false;
        }

        public void runSuccess()
        {
            foreach (SuccessModule successModule in successModules)
            {
                successModule.run();
            }
        }

        public string[] getStatusesWithMessages()
        {
            List<String> statusesWithMessages = new List<String>();

            foreach (Module module in modules)
            {
                String message = module.ToString() + " : " + module.getStatus();

                if (module.getErrors().Length > 0)
                {
                    foreach (string error in module.getErrors())
                    {
                        message += "\n - " + error;
                    }
                }

                statusesWithMessages.Add(message);
            }

            return statusesWithMessages.ToArray();
        }

        public List<Module> getUnrestrictedModules()
        {
            List<Module> UnrestrictedModules = new List<Module>();

            foreach (Module module in this.modules)
            {
                if (module.isRestricted() == false)
                {
                    UnrestrictedModules.Add(module);
                }
            }

            return UnrestrictedModules;
        }
    }
}
