using MusicRecognitionProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Dao
{
    public class InputDevicesDao : IInputDevicesDao
    {
        private readonly string _filePath = "";

        public List<string> GetInputDevices()
        {
            List<string> inputDevices = new List<string>();

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
                var devices = searcher.Get();
                foreach (ManagementObject soundDevice in devices)
                {
                    string productName = soundDevice["ProductName"] as string;
                    string description = soundDevice["Description"] as string;
                    
                    if (!string.IsNullOrEmpty(productName) &&
                        (productName.ToLower().Contains("microphone") ||
                         productName.ToLower().Contains("input") ||
                         productName.ToLower().Contains("mic")))
                    {
                        inputDevices.Add(productName);
                    }
                    else if (!string.IsNullOrEmpty(description) &&
                             (description.ToLower().Contains("microphone") ||
                              description.ToLower().Contains("input") ||
                              description.ToLower().Contains("mic")))
                    {
                        if (!inputDevices.Contains(description))
                        {
                            inputDevices.Add(description);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(ex);
            }
            return inputDevices;
        }



    }
}
