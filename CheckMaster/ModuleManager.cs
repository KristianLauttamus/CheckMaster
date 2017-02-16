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
        public Dictionary<Module, List<Restriction>> modules;
        public Dictionary<SuccessModule, List<Restriction>> successModules;

        public ModuleManager()
        {
            this.modules = new Dictionary<Module, List<Restriction>>();
            this.successModules = new Dictionary<SuccessModule, List<Restriction>>();
        }

        public void init()
        {
            foreach (Module module in modules.Keys)
            {
                module.init();
            }
        }

        public void check()
        {
            foreach (Module module in modules.Keys)
            {
                module.check();
            }
        }

        public bool failed()
        {
            foreach (Module module in modules.Keys)
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
            foreach (SuccessModule successModule in successModules.Keys)
            {
                successModule.run();
            }
        }
    }
}
