using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class AppleMusicData
	{
		public List<AppleMusicPreview> Previews { get; set; }
		public AppleMusicArtwork Artwork { get; set; }
		public string ArtistName { get; set; }
		public string Url { get; set; }
		public int DiscNumber { get; set; }
		public List<string> GenreNames { get; set; }
		public int DurationInMillis { get; set; }
		public string ReleaseDate { get; set; }
		public string Name { get; set; }
		public string Isrc { get; set; }
		public string AlbumName { get; set; }
		public AppleMusicPlayParams PlayParams { get; set; }
		public int TrackNumber { get; set; }
		public string ComposerName { get; set; }
		public bool IsAppleDigitalMaster { get; set; }
		public bool HasLyrics { get; set; }
	}
}
