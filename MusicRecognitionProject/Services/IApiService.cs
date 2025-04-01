using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MusicRecognitionProject.Services
{
    interface IApiService
    {
        RestResponse RecognizeAudio(string path, CancellationTokenSource token);
    }
}
