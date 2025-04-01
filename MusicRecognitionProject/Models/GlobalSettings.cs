using NAudio.Wave;

namespace MusicRecognitionProject.Models
{
    public class GlobalSettings
    {
        public string             ApiToken              { get; set; }
        public WaveInCapabilities SelectedInputDevice   { get; set; }
        public List<string>       SelectedPlatforms     { get; set; }
    }
}
