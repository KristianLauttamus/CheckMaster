using CheckMaster.Restrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster.SuccessModules
{
    public interface SuccessModule
    {
        Control[] getEditControls();
        void run();

        #region Restrictions
        void addRestriction(Restriction restriction);
        void addRestrictions(Restriction[] restrictions);
        void clearRestrictions();
        void removeRestriction(int index);
        void initRestrictions();
        bool isRestricted();
        List<Restriction> getRestrictions();
        #endregion
    }
}
