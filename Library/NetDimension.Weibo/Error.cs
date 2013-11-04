using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;
namespace NetDimension.Weibo
{
	/// <summary>
	/// 错误类
	/// </summary>
	public class Error
	{
		/// <summary>
		/// 错误编码
		/// </summary>
		[JsonProperty(PropertyName = "error_code")]
		public string Code
		{
			get;
			internal set;
		}
		/// <summary>
		/// 请求地址
		/// </summary>
		[JsonProperty(PropertyName = "request")]
		public string Request
		{
			get;
			internal set;
		}
		/// <summary>
		/// 消息
		/// </summary>
		[JsonProperty(PropertyName = "error_description")]
		public string Message
		{
			get;
			internal set;
		}
	}
}
