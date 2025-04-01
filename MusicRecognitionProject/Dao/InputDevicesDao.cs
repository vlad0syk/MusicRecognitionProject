using System.Linq;
using System.Management;
using MusicRecognitionProject.Utils;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MusicRecognitionProject.Dao
{
    public class InputDevicesDao : IInputDevicesDao
    {
        public List<WaveInCapabilities> GetInputDevices()
        {
            List<WaveInCapabilities> inputDevices = new List<WaveInCapabilities>();

            try
            {
                var enumerator = new MMDeviceEnumerator();
                for (int i = 0; i < WaveIn.DeviceCount; i++) 
                {
                    var inputDevice = WaveIn.GetCapabilities(i);
                    //inputDevice.ProductName = (enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)[i].FriendlyName);
                    inputDevices.Add(inputDevice);
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(ex);
                return inputDevices;
            }
            return inputDevices;
        }
    }
}
