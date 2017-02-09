using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.SuccessModules
{
    interface SuccessModule
    {
        string getName();
        Control[] getEditControls();
    }
}
