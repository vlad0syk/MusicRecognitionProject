using MusicRecognitionProject.Dao;
using MusicRecognitionProject.Helpers;
using MusicRecognitionProject.Models;
using MusicRecognitionTranslations;
using System.Globalization;
using MusicRecognitionProject.Models.Enums;

namespace MusicRecognitionProject.ViewModels
{
	public class SettingsViewModel : BindableBase
	{
		private readonly ITranslationsDao _translationsDao;
		private readonly IInputDevicesDao _inputDevicesDao;
		private readonly IGlobalSettingsDao _globalSettingsDao;

		private readonly GlobalSettings _globalSettings = new GlobalSettings();
		private readonly List<string> _selectedPlatforms = new List<string>();

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

		#region string SelectedInputDevice

		private string _selectedInputDevice;

		public string SelectedInputDevice
		{
			get => _selectedInputDevice;
			set => SetProperty(ref _selectedInputDevice, value);
		}

		#endregion

		#region List<string> InputDevices

		private List<string> _inputDevices = new();

		public List<string> InputDevices
		{
			get => _inputDevices;
			set => SetProperty(ref _inputDevices, value);
		}

		#endregion

		#region List<string> Platforms

		private List<string> _platforms = new List<string>();

		public List<string> Platforms
		{
			get => _platforms;
			set => SetProperty(ref _platforms, value);
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

		public SettingsViewModel(ITranslationsDao translationsDao, IInputDevicesDao inputDevicesDao,
			IGlobalSettingsDao globalSettingsDao)
		{
			_translationsDao = translationsDao;
			_inputDevicesDao = inputDevicesDao;
			_globalSettingsDao = globalSettingsDao;
			var culture = _translationsDao.LoadLanguage();
			AvailableLanguages = Translations.Instance.AvailableLanguages.ToList();
			Translations.Instance.CurrentLanguage = culture;
			CultureInfo info = new CultureInfo(culture);
			_selectedLanguage = info.NativeName;

			var devices = inputDevicesDao.GetInputDevices();

			foreach (var device in devices)
			{
				InputDevices.Add(device.ProductName);
			}

			_globalSettings = _globalSettingsDao.Read();
			SelectedInputDevice = _globalSettings.SelectedInputDevice.ProductName;

			Platforms = EnumToListConverter.ConvertPlatformsEnumToList();

			SaveCommand = new DelegateCommand(Save);
			CheckedCommand = new DelegateCommand(Checked);
			UncheckedCommand = new DelegateCommand(Unchecked);
		}

		#region DelegateCommand SaveCommand

		public DelegateCommand SaveCommand { get; }

		private void Save()
		{
			var devices = _inputDevicesDao.GetInputDevices();
			GlobalSettings globalSettings = new GlobalSettings
			{
				ApiToken = Cryptography.Encrypt(ApiToken),
			};

			foreach (var device in devices)
			{
				if (device.ProductName == SelectedInputDevice)
				{
					globalSettings.SelectedInputDevice =
						new AudioDevice
						{
							Channels = device.Channels,
							ManufacturerGuid = device.ManufacturerGuid,
							ProductGuid = device.ProductGuid,
							ProductName = device.ProductName
						};
				}
			}

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
