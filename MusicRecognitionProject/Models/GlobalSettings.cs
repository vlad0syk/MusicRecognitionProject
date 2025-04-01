using MusicRecognitionProject.Models.Enums;
using NAudio.Wave;

namespace MusicRecognitionProject.Models
{
    public class GlobalSettings
    {
        public string ApiToken { get; set; } = string.Empty;
        public AudioDevice SelectedInputDevice { get; set; } = null;
        public List<Platforms> SelectedPlatforms { get; set; } = new();
    }
}
