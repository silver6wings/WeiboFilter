using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.shortUrl
{
	public class ShareCounts : EntityBase
	{
		[JsonProperty("url_short")]
		public string ShortUrl { get; internal set; }
		[JsonProperty("url_long")]
		public string LongUrl { get; internal set; }
		[JsonProperty("share_counts")]
		public string Counts { get; internal set; }

	}
}
