using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NAudio.Wave;

namespace MusicRecognitionProject.Models
{
    public class AudioDevice
    {
        public AudioDevice(WaveInCapabilities input, int deviceId)
        { 
            Channels = input.Channels;
            ProductName = input.ProductName;
            ProductGuid = input.ProductGuid;
            ManufacturerGuid = input.ManufacturerGuid;
            DeviceId = deviceId;
        }

        public int Channels { get; set; }
        public string ProductName { get; set; }
        public Guid ProductGuid { get; set; }
        public Guid ManufacturerGuid { get; set; }
        public int DeviceId { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
    }
}
