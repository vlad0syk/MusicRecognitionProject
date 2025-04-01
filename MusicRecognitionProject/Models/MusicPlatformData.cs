using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public abstract class MusicPlatformData
	{
		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("link")]
		public string Link { get; set; }

		[JsonPropertyName("release_date")]
		public string ReleaseDate { get; set; }

		[JsonPropertyName("artist")]
		public ArtistInfo? Artist { get; set; }

		[JsonPropertyName("album")]
		public AlbumInfo? Album { get; set; }

		[JsonPropertyName("contributors")]
		public List<ArtistInfo>? Contributors { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; }
	}
}
