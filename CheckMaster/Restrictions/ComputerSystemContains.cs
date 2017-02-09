using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMaster.Restrictions
{
    class ComputerSystemContains : Restriction
    {
        public string contain;
        public bool DoesNotContain;
        private Dictionary<string, string> computersystem;

        public ComputerSystemContains()
        {
            this.contain = "";
            this.DoesNotContain = false;
            this.computersystem = new Dictionary<string, string>();
        }

        public override bool approved()
        {
            return true;
        }

        public override void init()
        {
            computersystem = WMIController.getComputerSystemInfo();
        }
    }
}
