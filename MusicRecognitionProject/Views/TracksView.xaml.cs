using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicRecognitionProject.ViewModels;

namespace MusicRecognitionProject.Views
{
    /// <summary>
    /// Interaction logic for TracksView.xaml
    /// </summary>
    public partial class TracksView : UserControl
    {
        public TracksView()
        {
            InitializeComponent();
        }

        private void StackPanel_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var selected = ((sender as StackPanel).DataContext as TracksViewModel).SelectedResult;
            if (selected != null)
            {
                string url = "https://open.spotify.com/track/" + selected.Spotify.Id; // Assuming SelectedResult has a property Url
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open URL: {ex.Message}");
                }
            }
        }

        private void Image_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var selected = ((sender as Image).DataContext as TracksViewModel).SelectedResult;
            if (selected != null)
            {
                string url = "https://open.spotify.com/track/" + selected.Spotify.Id; // Assuming SelectedResult has a property Url
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open URL: {ex.Message}");
                }
            }
        }
    }
}
