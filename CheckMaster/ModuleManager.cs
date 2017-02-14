﻿using CheckMaster.Modules;
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
        private Dictionary<Module, Status> statuses;

        public ModuleManager()
        {
            this.modules = new List<Module>();
            this.successModules = new List<SuccessModule>();
            this.statuses = new Dictionary<Module, Status>();
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
            this.statuses.Clear();

            foreach (Module module in modules)
            {
                module.check();

                this.statuses.Add(module, module.getStatus());
            }
        }

        public bool failed()
        {
            if (this.statuses.Count == 0)
            {
                return false;
            }

            return this.statuses.ContainsValue(Status.ERROR) || this.statuses.ContainsValue(Status.FAIL);
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
