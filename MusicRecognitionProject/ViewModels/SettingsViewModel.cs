using MusicRecognitionProject.Dao;
using MusicRecognitionProject.Helpers;
using MusicRecognitionProject.Models;
using MusicRecognitionTranslations;
using System.Globalization;
using Microsoft.VisualBasic.Devices;
using MusicRecognitionProject.Models.Enums;
using SpotifyAPI.Web;

namespace MusicRecognitionProject.ViewModels
{
	public class SettingsViewModel : BindableBase
	{
		private readonly ITranslationsDao _translationsDao;
		private readonly IInputDevicesDao _inputDevicesDao;
		private readonly IGlobalSettingsDao _globalSettingsDao;

		private readonly GlobalSettings _globalSettings;

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

        private List<SelectableViewModel<Platforms>> _platforms = new();
        public List<SelectableViewModel<Platforms>> Platforms
        {
			get => _platforms;
            set => SetProperty(ref _platforms, value);
        }

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

		#region string SelectedInputDevice

		private int _selectedInputDevice;
		public int SelectedInputDevice
        {
			get => _selectedInputDevice;
			set => SetProperty(ref _selectedInputDevice, value);
		}

		#endregion

		#region List<string> InputDevices

		private List<AudioDevice> _inputDevices = new();
		public List<AudioDevice> InputDevices
		{
			get => _inputDevices;
			set => SetProperty(ref _inputDevices, value);
		}

		#endregion


		#region string ApiToken

		private string _apiToken;
		public string ApiToken
		{
			get => _apiToken;
			set => SetProperty(ref _apiToken, value);
		}

		#endregion

		public SettingsViewModel(ITranslationsDao translationsDao, IInputDevicesDao inputDevicesDao, IGlobalSettingsDao globalSettingsDao)
		{
			_translationsDao = translationsDao;
			_inputDevicesDao = inputDevicesDao;
			_globalSettingsDao = globalSettingsDao;
			var culture = _translationsDao.LoadLanguage();
			AvailableLanguages = Translations.Instance.AvailableLanguages.ToList();
			Translations.Instance.CurrentLanguage = culture;
			CultureInfo info = new CultureInfo(culture);
			_selectedLanguage = info.NativeName;

			Platforms = Enum.GetValues(typeof(Platforms)).Cast<Platforms>().Select(p => new SelectableViewModel<Platforms>(p)).ToList();

            InputDevices = inputDevicesDao.GetInputDevices();

			_globalSettings = _globalSettingsDao.Read();
			SelectedInputDevice = _globalSettings.SelectedInputDevice.DeviceId;

            foreach (var platform in _globalSettings.SelectedPlatforms)
            {
                Platforms.First(p => p.Data == platform).IsSelected = true;
            }

			SaveCommand = new DelegateCommand(Save);
			CheckedCommand = new DelegateCommand(Checked);
			UncheckedCommand = new DelegateCommand(Unchecked);
		}

		#region DelegateCommand SaveCommand

		public DelegateCommand SaveCommand { get; }

		private void Save()
		{
            GlobalSettings globalSettings = new();

			if(!string.IsNullOrEmpty(ApiToken))
				globalSettings.ApiToken = Cryptography.Encrypt(ApiToken);

            globalSettings.SelectedInputDevice = InputDevices[SelectedInputDevice];
            globalSettings.SelectedPlatforms = Platforms.Where(p => p.IsSelected).Select(p => p.Data).ToList();

            _globalSettingsDao.Write(globalSettings);
		}
		 
		#endregion

		public DelegateCommand CheckedCommand { get; }
		private void Checked()
		{

		}

		public DelegateCommand UncheckedCommand { get; }
		private void Unchecked()
		{

		}
	}
}
