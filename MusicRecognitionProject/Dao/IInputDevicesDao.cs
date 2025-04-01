using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Dao
{
    public interface IInputDevicesDao
    {
        public List<string> GetInputDevices();
    }
}
