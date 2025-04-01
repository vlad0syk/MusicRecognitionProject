using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicRecognitionProject.Dao;
using MusicRecognitionProject.Models.Events;

namespace MusicRecognitionProject.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IEventAggregator eventAggregator, IMusicResultDao musicResultDao)
        {
            eventAggregator.GetEvent<TrackFoundEvent>().Subscribe(OnTrackFound);
            musicResultDao.Read();
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
