using CheckMaster.Restrictions;
using CheckMaster.SuccessModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster
{
    class RestrictedSuccessModule : SuccessModule
    {
        private List<Restriction> restrictions;
        public SuccessModule successModule;

        public RestrictedSuccessModule()
        {
            this.restrictions = new List<Restriction>();
            this.successModule = null;
        }

        public Control[] getEditControls()
        {
            if (successModule != null)
                return successModule.getEditControls();

            return new Control[0];
        }

        public void run()
        {
            if (successModule != null)
                successModule.run();
        }
    }
}
