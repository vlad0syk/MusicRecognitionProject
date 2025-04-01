using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class MusicResult
	{
		public string Artist { get; set; }
		public string Title { get; set; }
		public string Album { get; set; }
		public string ReleaseDate { get; set; }
		public string Label { get; set; }
		public string Timecode { get; set; }
		public string SongLink { get; set; }
		public AppleMusicData AppleMusic { get; set; }
		public List<MusicBrainzData> MusicBrainz { get; set; }
		public DeezerData Deezer { get; set; }
		public SpotifyData Spotify { get; set; }
	}
}
