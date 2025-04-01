using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class DeezerData : MusicPlatformData
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("readable")]
		public bool Readable { get; set; }

		[JsonPropertyName("title_short")]
		public string TitleShort { get; set; }

		[JsonPropertyName("title_version")]
		public string TitleVersion { get; set; }

		[JsonPropertyName("isrc")]
		public string Isrc { get; set; }

		[JsonPropertyName("share")]
		public string Share { get; set; }

		[JsonPropertyName("duration")]
		public int Duration { get; set; }

		[JsonPropertyName("track_position")]
		public int TrackPosition { get; set; }

		[JsonPropertyName("disk_number")]
		public int DiskNumber { get; set; }

		[JsonPropertyName("rank")]
		public int Rank { get; set; }

		[JsonPropertyName("explicit_lyrics")]
		public bool ExplicitLyrics { get; set; }

		[JsonPropertyName("explicit_content_lyrics")]
		public int ExplicitContentLyrics { get; set; }

		[JsonPropertyName("explicit_content_cover")]
		public int ExplicitContentCover { get; set; }

		[JsonPropertyName("preview")]
		public string Preview { get; set; }

		[JsonPropertyName("bpm")]
		public int Bpm { get; set; }

		[JsonPropertyName("gain")]
		public double Gain { get; set; }

		[JsonPropertyName("available_countries")]
		public List<string>? AvailableCountries { get; set; }

		[JsonPropertyName("md5_image")]
		public string Md5Image { get; set; }
	}
}
