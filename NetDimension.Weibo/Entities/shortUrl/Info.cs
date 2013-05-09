using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;
namespace NetDimension.Weibo.Entities.shortUrl
{
	public class Info : EntityBase
	{
		[JsonProperty("url_short")]
		public string ShortUrl { get; internal set; }
		[JsonProperty("url_long")]
		public string LongUrl { get; internal set; }
		[JsonProperty("type")]
		public string Type { get; internal set; }
		[JsonProperty("result")]
		public bool Result { get; internal set; }
		[JsonProperty("title")]
		public string Title { get; internal set; }
		[JsonProperty("description")]
		public string Description { get; internal set; }
		[JsonProperty("annotations")]
		public object Annotations { get; internal set; }
		[JsonProperty("last_modified")]
		public string LastModified { get; internal set; }
	}
}
