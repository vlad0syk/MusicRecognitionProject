using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.ViewModels
{
    public class TracksViewModel : BindableBase
    {
        public TracksViewModel()
        {
            
        }


        private List<object> _lastObjects;
        public List<object> LastObjects
        {
            get => _lastObjects;
            set => SetProperty(ref _lastObjects, value);
        }
    }
}
