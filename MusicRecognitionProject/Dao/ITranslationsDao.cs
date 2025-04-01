namespace MusicRecognitionProject.Dao
{
    public interface ITranslationsDao
    {
        string LoadLanguage();
        void SaveLanguage(string culture);
    }
}
