using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class MusicBrainzData
	{
		public string Id { get; set; }
		public int Score { get; set; }
		public string Title { get; set; }
		public int Length { get; set; }
		public string Disambiguation { get; set; }
		public List<MusicBrainzArtistCredit> ArtistCredit { get; set; }
		public List<MusicBrainzRelease> Releases { get; set; }
	}
}
