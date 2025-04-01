using MusicRecognitionProject.Utils;
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
                for (int i = 0; i < WaveIn.DeviceCount; i++) 
                {
                    inputDevices.Add(WaveIn.GetCapabilities(i));
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
