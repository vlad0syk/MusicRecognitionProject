using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MusicRecognitionProject.Dao;
using MusicRecognitionProject.Models;
using MusicRecognitionProject.Models.Events;

namespace MusicRecognitionProject.ViewModels
{
    public class TracksViewModel : BindableBase
    {
        private readonly IMusicResultDao _musicResultDao;
        public TracksViewModel(IMusicResultDao musicResultDao, IEventAggregator eventAggregator)
        {
            _musicResultDao = musicResultDao;

            LastResults = _musicResultDao.GetLast();

            eventAggregator.GetEvent<TrackFoundEvent>().Subscribe(OnTrackFound);
        }

        private void OnTrackFound()
        {
            LastResults = _musicResultDao.GetLast();
            SelectedResult = LastResults.LastOrDefault();
        }


        private List<MusicResult> _lasResults;
        public List<MusicResult> LastResults
        {
            get => _lasResults;
            set => SetProperty(ref _lasResults, value);
        }

        private MusicResult _selectedResult;
        public MusicResult SelectedResult
        {
            get => _selectedResult;
            set => SetProperty(ref _selectedResult, value);
        }
    }
}
