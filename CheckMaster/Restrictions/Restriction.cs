using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMaster.Restrictions
{
    interface Restriction
    {
        void init();
        bool approved();
    }
}
