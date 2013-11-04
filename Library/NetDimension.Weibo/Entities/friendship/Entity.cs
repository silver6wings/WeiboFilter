using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.friendship
{
	public class Entity : EntityBase
	{
		[JsonProperty("id")]
		public string ID { get; internal set; }
		[JsonProperty("screen_name")]
		public string ScreenName { get; internal set; }
		[JsonProperty("followed_by")]
		public bool FollowedBy { get; internal set; }
		[JsonProperty("following")]
		public bool Following { get; internal set; }
		[JsonProperty("notifications_enabled")]
		public bool NotificationsEnabled { get; internal set; }
	}
}
