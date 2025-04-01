using MusicRecognitionProject.Dao;
using MusicRecognitionTranslations;
using System.Globalization;

namespace MusicRecognitionProject.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private readonly ITranslationsDao _translationsDao;

        

        #region string SelectedLanguage

        private string _selectedLanguage; 
        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                SetProperty(ref _selectedLanguage, value);
                {
                    var culture = (from s in _availableLanguages
                                   where new CultureInfo(s).NativeName == _selectedLanguage
                                   select s).FirstOrDefault();
                    Translations.Instance.CurrentLanguage = culture!;
                    _translationsDao.SaveLanguage(culture!);
                }
            }
        }

        #endregion

        #region List<string> AvailableLanguages

        private List<string> _availableLanguages; 
        public List<string> AvailableLanguages
        {
            get
            {
                List<string> result = new List<string>();
                foreach (var s in _availableLanguages)
                {
                    var cultureInfo = new CultureInfo(s);
                    result.Add(cultureInfo.NativeName);
                }
                return result;
            }
            set => SetProperty(ref _availableLanguages, value);
        }

        #endregion

        public SettingsViewModel(ITranslationsDao translationsDao)
        {
            _translationsDao                      = translationsDao;
            var culture                           = _translationsDao.LoadLanguage();
            AvailableLanguages                    = Translations.Instance.AvailableLanguages.ToList();
            Translations.Instance.CurrentLanguage = culture;
            CultureInfo info                      = new CultureInfo(culture);
            _selectedLanguage                     = info.NativeName;
        }

    }
}
