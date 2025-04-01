using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class MusicBrainzRelease
	{
		public string Id { get; set; }
		public int Count { get; set; }
		public string Title { get; set; }
		public string Status { get; set; }
		public string Date { get; set; }
		public string Country { get; set; }
		public List<MusicBrainzReleaseEvent> ReleaseEvents { get; set; }
	}
}
