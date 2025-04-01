using MusicRecognitionProject.Models;
using Newtonsoft.Json;
using System.IO;

namespace MusicRecognitionProject.Dao
{
    public class GlobalSettingsDao : IGlobalSettingsDao
    {
        private readonly string _filePath = "GlobalSettings.config";

        public GlobalSettings Read()
        {
            if (!File.Exists(_filePath))
            {
                return new GlobalSettings();
            }
            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<GlobalSettings>(json)!;
        }
        public void Write(GlobalSettings globalSettings)
        {
            string json = JsonConvert.SerializeObject(globalSettings, Formatting.Indented);
            File.WriteAllText(json, _filePath);
        }
    }
}
