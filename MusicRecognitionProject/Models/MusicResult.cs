using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class MusicResult
	{
        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("album")]
        public string Album { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("timecode")]
        public string Timecode { get; set; }

        [JsonPropertyName("song_link")]
        public string SongLink { get; set; }
        //public AppleMusicData AppleMusic { get; set; }
        //public List<MusicBrainzData> MusicBrainz { get; set; }
        //public DeezerData Deezer { get; set; }

        [JsonPropertyName("spotify")]
        public SpotifyData Spotify { get; set; }
	}
}
