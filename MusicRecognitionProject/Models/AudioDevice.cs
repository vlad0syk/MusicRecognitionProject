using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
    public class AudioDevice
    {
        public int Channels { get; set; }
        public string ProductName { get; set; }
        public Guid ProductGuid { get; set; }
        public Guid ManufacturerGuid { get; set; }
	}
}
