using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities
{
	public class SchoolEntity : EntityBase
	{
		[JsonProperty("id")]
		public string ID { get; internal set; }
		[JsonProperty("name")]
		public string Name { get; internal set; }
	}
}
