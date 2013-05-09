using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;
namespace NetDimension.Weibo.Entities
{
	public class UnreadCountResult : EntityBase
	{
		[JsonProperty("status")]
		public string Status{get;internal set;}
		[JsonProperty("follower")]
		public string Follower { get; internal set; }
		[JsonProperty("cmt")]
		public string Comment { get; internal set; }
		[JsonProperty("dm")]
		public string DirectMessage { get; internal set; }
		[JsonProperty("mention_status")]
		public string MentionStatus { get; internal set; }
		[JsonProperty("mention_cmt")]
		public string MentionComment { get; internal set; }
		[JsonProperty("group")]
		public string Group { get; internal set; }
		[JsonProperty("private_group")]
		public string PrivateGroup { get; internal set; }
		[JsonProperty("notice")]
		public string Notice { get; internal set; }
		[JsonProperty("invite")]
		public string Invite { get; internal set; }
		[JsonProperty("badge")]
		public string Badge { get; internal set; }
		[JsonProperty("photo")]
		public string Photo { get; internal set; }

	}
}
