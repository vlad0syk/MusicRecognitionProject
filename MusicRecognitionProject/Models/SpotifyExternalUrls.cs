using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class SpotifyExternalUrls
	{
		[JsonPropertyName("spotify")]
		public string Spotify { get; set; }
	}
}
