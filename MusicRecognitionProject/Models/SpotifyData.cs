using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class SpotifyData : MusicPlatformData
	{
		[JsonPropertyName("album")]
		public SpotifyAlbum Album { get; set; }

		[JsonPropertyName("external_ids")]
		public SpotifyExternalIds ExternalIds { get; set; }

		[JsonPropertyName("popularity")]
		public int Popularity { get; set; }

		[JsonPropertyName("is_playable")]
		public bool IsPlayable { get; set; }

		[JsonPropertyName("linked_from")]
		public object? LinkedFrom { get; set; }

		[JsonPropertyName("available_markets")]
		public List<string>? AvailableMarkets { get; set; }

		[JsonPropertyName("disc_number")]
		public int DiscNumber { get; set; }

		[JsonPropertyName("duration_ms")]
		public int DurationMs { get; set; }

		[JsonPropertyName("explicit")]
		public bool Explicit { get; set; }

		[JsonPropertyName("external_urls")]
		public SpotifyExternalUrls ExternalUrls { get; set; }

		[JsonPropertyName("href")]
		public string Href { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("preview_url")]
		public string PreviewUrl { get; set; }

		[JsonPropertyName("track_number")]
		public int TrackNumber { get; set; }

		[JsonPropertyName("uri")]
		public string Uri { get; set; }
	}
}
