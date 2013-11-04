using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.friendship
{
	public class Result : EntityBase
	{
		[JsonProperty("target")]
		public Entity Target { get; internal set; }
		[JsonProperty("source")]
		public Entity Source { get; internal set; }
	}
}
