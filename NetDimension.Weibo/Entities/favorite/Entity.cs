using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.favorite
{
	public class Entity : EntityBase
	{
		[JsonProperty("status")]
		public status.Entity Status { get; internal set; }

		[JsonProperty("tags")]
		public IEnumerable<TagEntity> Tags { get; internal set; }

		[JsonProperty("favorited_time")]
		public string FavoritedTime { get; internal set; }
	}
}
