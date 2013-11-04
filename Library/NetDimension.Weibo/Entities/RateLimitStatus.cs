using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities
{
	public class RateLimitStatus : EntityBase
	{
		[JsonProperty("ip_limit")]
		public int IPLimit;
		[JsonProperty("limit_time_unit")]
		public string LimitTimeUnit;
		[JsonProperty("remaining_ip_hits")]
		public int RemainingIPHits;
		[JsonProperty("remaining_user_hits")]
		public int RemainingUserHits;
		[JsonProperty("reset_time")]
		public DateTime ResetTime;
		[JsonProperty("reset_time_in_seconds")]
		public int ResetTimeInSeconds;
		[JsonProperty("user_limit")]
		public int UserLimit;
	}
}
