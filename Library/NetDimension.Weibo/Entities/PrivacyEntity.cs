using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;
namespace NetDimension.Weibo.Entities
{
	public class PrivacyEntity : EntityBase
	{
		[JsonProperty("badge")]
		public int Badge{get;internal set;}
		[JsonProperty("comment")]
		public int Comment { get; internal set; }
		[JsonProperty("geo")]
		public int GEO { get; internal set; }
		[JsonProperty("message")]
		public int Message { get; internal set; }
		[JsonProperty("mobile")]
		public int Mobile { get; internal set; }
		[JsonProperty("realname")]
		public int RealName { get; internal set; }
	}
}
