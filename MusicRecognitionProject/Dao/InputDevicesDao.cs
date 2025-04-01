using System.Linq;
using System.Management;
using MusicRecognitionProject.Models;
using MusicRecognitionProject.Utils;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace MusicRecognitionProject.Dao
{
    public class InputDevicesDao : IInputDevicesDao
    {
        public List<AudioDevice> GetInputDevices()
        {
            List<AudioDevice> inputDevices = new ();
            try
            {
                var enumerator = new MMDeviceEnumerator();
                for (int i = 0; i < WaveIn.DeviceCount; i++) 
                {
                    var inputDevice = new AudioDevice(WaveIn.GetCapabilities(i), i);
                    inputDevice.ProductName = (enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)[i].FriendlyName);
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
