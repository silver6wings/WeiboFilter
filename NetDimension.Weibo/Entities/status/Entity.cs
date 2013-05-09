using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.status
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

		[JsonProperty(PropertyName = "favorited")]
		public bool Favorited { get; internal set; }

		[JsonProperty(PropertyName = "truncated")]
		public bool Truncated { get; internal set; }

		[JsonProperty(PropertyName = "in_reply_to_status_id")]
		public string InReplyToStuatusID { get; internal set; }

		[JsonProperty(PropertyName = "in_reply_to_user_id")]
		public string InReplyToUserID { get; internal set; }

		[JsonProperty(PropertyName = "in_reply_to_screen_name")]
		public string InReplyToScreenName { get; internal set; }

		[JsonProperty(PropertyName = "thumbnail_pic")]
		public string ThumbnailPictureUrl { get; internal set; }

		[JsonProperty(PropertyName = "bmiddle_pic")]
		public string MiddleSizePictureUrl { get; internal set; }

		[JsonProperty(PropertyName = "original_pic")]
		public string OriginalPictureUrl { get; internal set; }

		[JsonProperty(PropertyName = "mid")]
		public string MID { get; internal set; }

		[JsonProperty(PropertyName = "reposts_count")]
		public int RepostsCount { get; internal set; }

		[JsonProperty(PropertyName = "comments_count")]
		public int CommentsCount { get; internal set; }

		[JsonProperty("annotations")]
		public object Annotations { get; internal set; }

		[JsonProperty(PropertyName = "geo")]
		public GeoEntity GEO { get; internal set; }

		[JsonProperty(PropertyName = "user")]
		public user.Entity User { get; internal set; }

		[JsonProperty(PropertyName = "retweeted_status")]
		public Entity RetweetedStatus { get; internal set; }

	}
}
