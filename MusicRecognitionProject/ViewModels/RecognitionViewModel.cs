using MusicRecognitionProject.Services;
using MusicRecognitionProject.Utils;
using NAudio.Wave;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using MusicRecognitionProject.Dao;
using MusicRecognitionProject.Models;
using MusicRecognitionProject.Models.Events;
using MusicRecognitionTranslations;
using Button = System.Windows.Controls.Button;
using DialogResult = System.Windows.Forms.DialogResult;
using MessageBox = System.Windows.MessageBox;

namespace MusicRecognitionProject.ViewModels
{
    class RecognitionViewModel : BindableBase
    {
        private readonly IApiService _apiService;
        private readonly IGlobalSettingsDao _globalSettingsDao;
        private readonly IInputDevicesDao _inputDevicesDao;
        private readonly IDialogCoordinator _dialogCoordinator;
        private readonly IEventAggregator _eventAggregator;

        private readonly GlobalSettings _globalSettings;
        private Button _button;
        private CancellationTokenSource _searchCancellationToken = new();

        public RecognitionViewModel(IApiService apiService, IGlobalSettingsDao globalGlobalSettingsDao, IInputDevicesDao inputDevicesDao, IDialogCoordinator dialogCoordinator, IEventAggregator eventAggregator)
        {
            OpenFileCommand = new DelegateCommand(OpenFile);
            RecognizeFromMicCommand = new DelegateCommand(RecognizeFromMic);
            ControlLoadedCommand = new DelegateCommand<Button>(ControlLoaded);
            FooCommand = new DelegateCommand(Foo);

            _apiService = apiService;
            _globalSettingsDao = globalGlobalSettingsDao;
            _inputDevicesDao = inputDevicesDao;
            _dialogCoordinator = dialogCoordinator;

            _globalSettings = _globalSettingsDao.Read();
            AvailableDevices = _inputDevicesDao.GetInputDevices();
            SelectedDevice = _globalSettings.SelectedInputDevice.DeviceId;
            _eventAggregator = eventAggregator;
        }

        private bool _isNotSearching = true;
        public bool IsNotSearching
        {
            get => _isNotSearching;
            set => SetProperty(ref _isNotSearching, value);
        }

        private bool _isSpinning;
        public bool IsSpinning
        {
            get => _isSpinning;
            set => SetProperty(ref _isSpinning, value, ChangeAnimationState);
        }

        private List<AudioDevice> _availableDevices;
        public List<AudioDevice> AvailableDevices
        {
            get => _availableDevices;
            set => SetProperty(ref _availableDevices, value);
        }

        private int _selectedDevice;
        public int SelectedDevice
        {
            get => _selectedDevice;
            set => SetProperty(ref _selectedDevice, value);
        }

        private void ChangeAnimationState()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (_isSpinning)
                {
                    var rotateTransform = new RotateTransform();
                    _button.RenderTransform = rotateTransform;
                    _button.RenderTransformOrigin = new Point(0.5, 0.5);

                    var animation = new DoubleAnimation
                    {
                        To = 360,
                        Duration = new Duration(TimeSpan.FromSeconds(3)),
                        RepeatBehavior = RepeatBehavior.Forever
                    };

                    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
                }
                else
                {
                    if (_button.RenderTransform is RotateTransform rotateTransform)
                    {
                        rotateTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                    }
                }
            });
        }


        public DelegateCommand OpenFileCommand { get; }
        private void OpenFile()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Audio Files|*.mp3;*.wav;*.flac;*.aac;*.ogg;*.wma"
                };

                if (openFileDialog.ShowDialog().Value)
                {
                    IsNotSearching = false;
                    IsSpinning = true;
                    string filePath = openFileDialog.FileName;

                    Task.Factory.StartNew(() =>
                    {
                        var result = _apiService.RecognizeAudio(filePath, _searchCancellationToken);

                        Logger.OutputInfo("Search result: " + result.IsSuccessful);

                        IsNotSearching = true;
                        IsSpinning = false;
                        if (result.IsSuccessful)
                        {
                            string formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(result.Content), Formatting.Indented);
                            File.WriteAllText("result.txt", formattedJson);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(ex);
            }
        }

        public DelegateCommand RecognizeFromMicCommand { get; }
        private void RecognizeFromMic()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    if (IsSpinning)
                    {
                        _searchCancellationToken.Cancel();
                        IsSpinning = false;
                    }
                    else
                    {
                        _searchCancellationToken = new();
                        IsSpinning = true;
                        IsNotSearching = false;
                        int count = 0;

                        while (true)
                        {
                            string outputFilePath = "tempFile.wav";
                            if (File.Exists(outputFilePath))
                                File.Delete(outputFilePath);

                            int recordingDuration = 10; // seconds

                            using (var waveIn = new WaveInEvent { DeviceNumber = SelectedDevice })
                            using (var writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat))
                            {
                                waveIn.DataAvailable += (s, e) => writer.Write(e.Buffer, 0, e.BytesRecorded);
                                waveIn.StartRecording();

                                Thread.Sleep(recordingDuration * 1000);

                                waveIn.StopRecording();
                            }

                            var result = _apiService.RecognizeAudio(outputFilePath, _searchCancellationToken);

                            Logger.OutputInfo("Search result: " + result.IsSuccessful);

                            if (result.IsSuccessful && !string.IsNullOrEmpty(result.Content))
                            {
                                File.WriteAllText("result.txt", result.Content);

                                /*
                                 *
                                 * save track logic
                                 *
                                 */

                                _eventAggregator.GetEvent<TrackFoundEvent>().Publish();
                                break;
                            }

                            if (++count >= 3)
                            {
                                _dialogCoordinator.ShowMessageAsync(this, Translations.Instance.Translate("lblError"), Translations.Instance.Translate("lblFoundNothing"));
                                break;
                            }
                        }
                    }

                    IsSpinning = false;
                    IsNotSearching = true;
                }
                catch (Exception ex)
                {
                    Logger.LogInfo(ex);
                }
            });
        }

        public DelegateCommand<Button> ControlLoadedCommand { get; }
        private void ControlLoaded(Button button)
        {
            _button = button;
        }



        public DelegateCommand FooCommand { get; }
        private void Foo()
        {
            IsSpinning = !IsSpinning;
        }
    }
}
