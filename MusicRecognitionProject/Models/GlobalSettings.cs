using MusicRecognitionProject.Models.Enums;
using NAudio.Wave;

namespace MusicRecognitionProject.Models
{
    public class GlobalSettings
    {
        public string                ApiToken              { get; set; }
        public AudioDevice           SelectedInputDevice   { get; set; }
        public List<Platforms>       SelectedPlatforms     { get; set; }
    }
}
