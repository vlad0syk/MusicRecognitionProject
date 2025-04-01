using NAudio.Wave;

namespace MusicRecognitionProject.Dao
{
    public interface IInputDevicesDao
    {
        public List<WaveInCapabilities> GetInputDevices();
    }
}
