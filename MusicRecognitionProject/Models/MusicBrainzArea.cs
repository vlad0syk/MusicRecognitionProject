using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRecognitionProject.Models
{
	public class MusicBrainzArea
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string SortName { get; set; }
		public List<string> Iso31661Codes { get; set; }
	}
}
