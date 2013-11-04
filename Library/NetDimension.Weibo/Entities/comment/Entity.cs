using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;
namespace NetDimension.Weibo.Entities.comment
{
	public class Entity : EntityBase
	{
		[JsonProperty(PropertyName = "created_at")]
		public string CreatedAt { get; internal set; }
		[JsonProperty(PropertyName = "id")]
		public string ID { get; internal set; }
		[JsonProperty(PropertyName = "text")]
		public string Text { get; internal set; }
		[JsonProperty(PropertyName = "source")]
		public string Source { get; internal set; }
		[JsonProperty(PropertyName = "user")]
		public user.Entity User { get; internal set; }
		[JsonProperty(PropertyName = "mid")]
		public string MID { get; internal set; }
		[JsonProperty(PropertyName = "status")]
		public status.Entity Status { get; internal set; }
		[JsonProperty(PropertyName = "reply_comment")]
		public Entity ReplyComment { get; internal set; }
	}
}
