using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CheckMaster
{
    static class WMIController
    {
        static public Dictionary<string, string> getComputerSystemInfo()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\cimv2",
                "SELECT * FROM Win32_ComputerSystem");

            Dictionary<string, string> queryResults = new Dictionary<string, string>();

            foreach (ManagementObject queryObj in searcher.Get())
            {
                queryResults.Add("Manufacturer", queryObj["Manufacturer"].ToString());
                queryResults.Add("Name", queryObj["Name"].ToString());
                queryResults.Add("Model", queryObj["Model"].ToString());
                queryResults.Add("SystemType", queryObj["SystemType"].ToString());
                queryResults.Add("UserName", queryObj["UserName"].ToString());
            }

            return queryResults;
        }
    }
}
