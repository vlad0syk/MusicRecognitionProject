using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class SpotifyAlbum
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("artists")]
		public List<ArtistInfo>? Artists { get; set; }

		[JsonPropertyName("album_group")]
		public string AlbumGroup { get; set; }

		[JsonPropertyName("album_type")]
		public string AlbumType { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("uri")]
		public string Uri { get; set; }

		[JsonPropertyName("available_markets")]
		public List<string>? AvailableMarkets { get; set; }

		[JsonPropertyName("href")]
		public string Href { get; set; }

		[JsonPropertyName("images")]
		public List<SpotifyImage>? Images { get; set; }

		[JsonPropertyName("external_urls")]
		public SpotifyExternalUrls ExternalUrls { get; set; }

		[JsonPropertyName("release_date")]
		public string ReleaseDate { get; set; }

		[JsonPropertyName("release_date_precision")]
		public string ReleaseDatePrecision { get; set; }
	}
}
