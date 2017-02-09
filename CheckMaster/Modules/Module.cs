using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.Modules
{
    interface Module
    {
        string getName();
        void init();
        void check();
        Status getStatus();
        string[] getErrors();
        Control[] getEditControls();
    }
}
