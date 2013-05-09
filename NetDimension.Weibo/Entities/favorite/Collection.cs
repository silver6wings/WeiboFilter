using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.favorite
{
	public class Collection : EntityBase
	{
		[JsonProperty("favorites")]
		public IEnumerable<Entity> Favorites { get; internal set; }
		[JsonProperty("total_number")]
		public int TotalNumber { get; internal set; }
	}
}
