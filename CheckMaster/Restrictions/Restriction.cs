using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMaster.Restrictions
{
    abstract class Restriction
    {
        public abstract void init();
        public abstract bool approved();
    }
}
