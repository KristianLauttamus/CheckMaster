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
        static public string[] getComputerSystemInfoOptions()
        {
            return new string[]
            {
                "Manufacturer",
                "Name",
                "Model",
                "SystemType",
                "UserName"
            };
        }

        static public Dictionary<string, string> getComputerSystemInfo()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\cimv2",
                "SELECT * FROM Win32_ComputerSystem");

            Dictionary<string, string> queryResults = new Dictionary<string, string>();

            foreach (ManagementObject queryObj in searcher.Get())
            {
                foreach (string option in getComputerSystemInfoOptions())
                {
                    queryResults.Add(option, queryObj[option].ToString());
                }
            }

            return queryResults;
        }

        static public string getVolumeID(string deviceID)
        {
            string VolumeID = "";
            ManagementObject classInstance =
                new ManagementObject("root\\CIMV2\\Security\\MicrosoftVolumeEncryption",
                "Win32_EncryptableVolume.DeviceID='" + deviceID + "'",
                null);

            // Obtain in-parameters for the method
            ManagementBaseObject inParams =
                classInstance.GetMethodParameters("GetKeyProtectors");

            // Add the input parameters.
            inParams["KeyProtectorType"] = 1;

            // Execute the method and obtain the return values.
            ManagementBaseObject outParams =
                classInstance.InvokeMethod("GetKeyProtectors", inParams, null);

            // List outParams
            Console.WriteLine("Out parameters:");
            Console.WriteLine("ReturnValue: " + outParams["ReturnValue"]);
            Console.WriteLine("VolumeKeyProtectorID: " + outParams["VolumeKeyProtectorID"]);

            foreach (var k in (String[])outParams["VolumeKeyProtectorID"])
            {
                VolumeID = k.ToString();
            }

            return VolumeID;
        }

        static public void removeTPM(string deviceID)
        {
            string VolumeID = getVolumeID(deviceID);

            ManagementObject classInstance =
                new ManagementObject("root\\CIMV2\\Security\\MicrosoftVolumeEncryption",
                "Win32_EncryptableVolume.DeviceID='" + deviceID + "'",
                null);

            // Obtain in-parameters for the method
            ManagementBaseObject inParams =
                classInstance.GetMethodParameters("DeleteKeyProtector");

            // Add the input parameters.
            inParams["VolumeKeyProtectorID"] = VolumeID;

            // Execute the method and obtain the return values.
            ManagementBaseObject outParams =
                classInstance.InvokeMethod("DeleteKeyProtector", inParams, null);

            // List outParams
            Console.WriteLine("Out parameters:");
            Console.WriteLine("ReturnValue: " + outParams["ReturnValue"]);
        }

        static public bool checkBitLockerStatus()
        {
            var path = new ManagementPath(@"\ROOT\CIMV2\Security\MicrosoftVolumeEncryption") { ClassName = "Win32_EncryptableVolume" };
            var scope = new ManagementScope(path);
            path.Server = Environment.MachineName;
            var objectSearcher = new ManagementClass(scope, path, new ObjectGetOptions());

            foreach (var item in objectSearcher.GetInstances())
            {
                return item["ProtectionStatus"].ToString() == "1";
            }

            return false;
        }

        static public string getDeviceID()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\CIMV2\\Security\\MicrosoftVolumeEncryption",
                "SELECT * FROM Win32_EncryptableVolume");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                return "" + queryObj["DeviceID"];
            }

            return "";
        }
    }
}
