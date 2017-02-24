using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckMaster.Restrictions;
using System.Diagnostics;

namespace CheckMaster.Modules
{
    [Serializable]
    class CheckBitlockerStatus : MasterModule
    {
        private Status status;
        private Stopwatch stopwatch;

        public override void init()
        {
            this.status = Status.NOTRUN;
        }

        /// <summary>
        /// Run only once every 5 seconds, since WMI queries are resource hogs
        /// </summary>
        public override void check()
        {
            // Start stopwatch
            if (stopwatch == null || stopwatch.IsRunning == false)
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();
            }

            // If under X amount of milliseconds, don't continue
            if (stopwatch.ElapsedMilliseconds < 5000)
            {
                return;
            }
            
            Console.WriteLine("Checking BitLocker status...");
            if (WMIController.checkBitLockerStatus())
            {
                this.status = Status.OK;
            }
            else
            {
                this.status = Status.FAIL;
            }

            // Restart stopwatch, so that it doesn't have to be
            // started again
            stopwatch.Restart();
        }

        public override Control[] getEditControls()
        {
            return new Control[0];
        }

        public override string[] getErrors()
        {
            if (this.status == Status.FAIL)
            {
                return new string[] { "Bitlocker is not ready yet" };
            }
            else if (this.status == Status.NOTRUN)
            {
                return new string[] { "Bitlocker hasn't ran yet" };
            }

            return new string[0];
        }

        public override Status getStatus()
        {
            return this.status;
        }

        public override string ToString()
        {
            return "Check Bitlocker Status";
        }
    }
}
