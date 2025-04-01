using MusicRecognitionProject.Models;

namespace MusicRecognitionProject.Dao
{
    public interface IGlobalSettingsDao
    {
        public GlobalSettings Read();
        public void Write(GlobalSettings globalSettings);
    }
}
