using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
    public class SelectableViewModel<T>(T data) : BindableBase
    {
        private T _data = data;
        public T Data 
        {
            get => _data; 
            set => SetProperty(ref _data, value);
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
