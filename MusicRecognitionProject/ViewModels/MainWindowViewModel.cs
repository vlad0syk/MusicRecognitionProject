using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicRecognitionProject.Models.Events;

namespace MusicRecognitionProject.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<TrackFoundEvent>().Subscribe(OnTrackFound);
        }

        private int _selectedTab;
        public int SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }
        private void OnTrackFound()
        {
            SelectedTab = 1;
        }
    }
}
