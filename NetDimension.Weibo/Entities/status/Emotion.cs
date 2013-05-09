using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.status
{
	public class Emotion : EntityBase
	{
		[JsonProperty("category")]
		public string Category{get;internal set;}
		[JsonProperty("common")]
		public bool Common { get; internal set; }
		[JsonProperty("hot")]
		public bool Hot { get; internal set; }
		[JsonProperty("icon")]
		public string Icon { get; internal set; }
		[JsonProperty("phrase")]
		public string Phrase { get; internal set; }
		[JsonProperty("picid")]
		public string PictureID { get; internal set; }
		[JsonProperty("type")]
		public string Type { get; internal set; }
		[JsonProperty("url")]
		public string Url { get; internal set; }
		[JsonProperty("value")]
		public string Value { get; internal set; }
	}
}
