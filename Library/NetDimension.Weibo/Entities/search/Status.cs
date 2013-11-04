using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.search
{
	public class Status : EntityBase
	{
		[JsonProperty("suggestion")]
		public string Suggestion { get; internal set; }
		[JsonProperty("count")]
		public int Count { get; internal set; }
	}
}
