using MusicRecognitionProject.Utils;
using System.Xml.Linq;

namespace MusicRecognitionProject.Dao
{
    internal class TranslationsDao : ITranslationsDao
    {
        private readonly string _configPath = AppDomain.CurrentDomain.BaseDirectory + @"\languageConfig.xml";

        public string LoadLanguage()
        {
            try
            {
                XDocument document = XDocument.Load(_configPath);
                string? language = document.Element("selectedLanguage")?.Value;
                return language ?? "en-GB";
            }
            catch (Exception ex)
            {
                Logger.LogInfo(ex.ToString());
                return "en-GB";
            }
        }
        public void SaveLanguage(string culture)
        {
            try
            {
                XDocument document = new XDocument();
                document.Add(new XElement("selectedLanguage", culture));
                document.Save(_configPath);
            }
            catch (Exception ex)
            {
                Logger.LogInfo(ex.ToString());
            }
        }

    }
}
