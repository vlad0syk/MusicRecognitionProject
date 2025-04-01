using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicRecognitionProject.Models;

public class MusicRecognitionResult
{
	[JsonPropertyName("status")]
	public string Status { get; set; }

	[JsonPropertyName("result")]
	public MusicResult Result { get; set; }
}