using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo
{
	public class AccessToken
	{
		[JsonProperty(PropertyName = "access_token")]
		public string Token{get;internal set;}
		[JsonProperty(PropertyName = "expires_in")]
		public int ExpiresIn{get;internal set;}
		[JsonProperty(PropertyName = "uid")]
		public string UID{get;internal set;}
	}
}
