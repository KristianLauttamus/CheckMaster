﻿using CheckMaster.Restrictions;
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
        void init();
        void check();
        Status getStatus();
        string[] getErrors();
        Control[] getEditControls();

        #region Restrictions
        void addRestriction(Restriction restriction);
        void removeRestriction(int index);
        void initRestrictions();
        bool isRestricted();
        List<Restriction> getRestrictions();
        #endregion
    }
}