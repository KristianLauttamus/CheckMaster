using CheckMaster.Modules;
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
        [XmlArray]
        public List<Module> modules;
        [XmlArray]
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
    }
}
