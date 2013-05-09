using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.favorite
{
	public class IDCollection : EntityBase
	{
		[JsonProperty("favorites")]
		public IEnumerable<IDEntity> Favorites { get; internal set; }
		[JsonProperty("total_number")]
		public int TotalNumber { get; internal set; }
	}
}
