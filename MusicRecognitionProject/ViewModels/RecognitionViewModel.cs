using MusicRecognitionProject.Services;
using MusicRecognitionProject.Utils;
using NAudio.Wave;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;
using Microsoft.Win32;
using Button = System.Windows.Controls.Button;
using DialogResult = System.Windows.Forms.DialogResult;
using MessageBox = System.Windows.MessageBox;

namespace MusicRecognitionProject.ViewModels
{
    class RecognitionViewModel : BindableBase
    {
        private readonly IApiService _apiService;
        private Button _button;
        private CancellationTokenSource searchCancellationToken = new();

        public RecognitionViewModel(IApiService apiService)
        {
            OpenFileCommand = new DelegateCommand(OpenFile);
            RecognizeFromMicCommand = new DelegateCommand(RecognizeFromMic);
            ControlLoadedCommand = new DelegateCommand<Button>(ControlLoaded);

            _apiService = apiService;
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

        private void ChangeAnimationState()
        {
            if (!_isSpinning)
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
                _isSpinning = true;
            }
            else
            {
                if (_button.RenderTransform is RotateTransform rotateTransform)
                {
                    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                }
                _isSpinning = false;
            }
        }


        public DelegateCommand OpenFileCommand { get; }
        private void OpenFile()
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

                var result = _apiService.RecognizeAudio(filePath, searchCancellationToken);

                Logger.OutputInfo("Search result: " + result.IsSuccessful);

                IsNotSearching = true;
                IsSpinning = false;
                if (result.IsSuccessful)
                {
                    string formattedJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(result.Content),
                        Formatting.Indented);
                    File.WriteAllText("result.txt", formattedJson);
                }
            }
        }

        public DelegateCommand RecognizeFromMicCommand { get; }
        private void RecognizeFromMic()
        {
            if (IsSpinning)
            {
                searchCancellationToken.Cancel();
            }
            else
            {

                IsSpinning = true;
                IsNotSearching = false;
                int count = 0;
                while (true)
                {
                    string outputFilePath = "tempFile.wav";
                    int recordingDuration = 5; // seconds

                    using (var waveIn = new WaveInEvent() { DeviceNumber = 0 })
                    using (var writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat))
                    {
                        waveIn.DataAvailable += (s, e) => writer.Write(e.Buffer, 0, e.BytesRecorded);
                        waveIn.StartRecording();

                        Thread.Sleep(recordingDuration * 1000);

                        waveIn.StopRecording();
                    }

                    var result = _apiService.RecognizeAudio(outputFilePath, searchCancellationToken);

                    Logger.OutputInfo("Search result: " + result.IsSuccessful);

                    if (result.IsSuccessful)
                    {
                        string formattedJson = JsonConvert.SerializeObject(
                            JsonConvert.DeserializeObject(result.Content),
                            Formatting.Indented);
                        File.WriteAllText("result.txt", formattedJson);
                        break;
                    }

                    if (count++ >= 3)
                    {
                        MessageBox.Show("No result found", "Error");
                        break;
                    }
                }

                IsSpinning = false;
                IsNotSearching = true;
            }
        }
        //todo: change device number

        public DelegateCommand<Button> ControlLoadedCommand { get; }
        private void ControlLoaded(Button button)
        {
            _button = button;
        }
    }
}
