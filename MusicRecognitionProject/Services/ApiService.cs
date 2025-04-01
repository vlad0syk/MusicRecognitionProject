using System.IO;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading;

namespace MusicRecognitionProject.Services
{
    class ApiService : IApiService
    {
        public RestResponse RecognizeAudio(string path, CancellationTokenSource token)
        {
            byte[] audioBytes = File.ReadAllBytes(path);
            var options = new RestClientOptions("https://api.audd.io/");
            var client = new RestClient(options);

            var request = new RestRequest("recognize", Method.Post);
            request.AddFile("file", path);
            request.AddParameter("api_token", "e840d49e8764851dc760302fea25d42b");
            request.AddParameter("return", "apple_music,spotify,musicbrainz,deezer,napster");

            return client.ExecuteAsync(request, token.Token).Result;
        }
    }
}
