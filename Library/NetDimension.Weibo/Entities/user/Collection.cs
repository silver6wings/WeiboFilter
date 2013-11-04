using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.user
{
	public class Collection : EntityBase
	{
		[JsonProperty("users")]
		public IEnumerable<Entity> Users { get; internal set; }
		[JsonProperty(PropertyName = "previous_cursor")]
		public string ProviousCursor { get; internal set; }
		[JsonProperty(PropertyName = "next_cursor")]
		public string NextCursor { get; internal set; }
		[JsonProperty(PropertyName = "total_number")]
		public int TotalNumber { get; internal set; }
	}
}
