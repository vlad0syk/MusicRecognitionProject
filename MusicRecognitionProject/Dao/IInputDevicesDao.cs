using MusicRecognitionProject.Models;
using NAudio.Wave;

namespace MusicRecognitionProject.Dao
{
    public interface IInputDevicesDao
    {
        public List<AudioDevice> GetInputDevices();
    }
}
