using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo
{
	/// <summary>
	/// 微博操作类
	/// </summary>
	public class Client
	{

		const string BASE_URL = "https://api.weibo.com/2/";

		/// <summary>
		/// OAuth实例
		/// </summary>
		public OAuth OAuth
		{
			get;
			private set;
		}

#if NET40
		/// <summary>
		/// 微博动态类型接口
		/// </summary>
		public Interface.InterfaceSelector API
		{
			get;
			private set;
		}		
#else
		public Interface.EntityInterfaces API
		{
			get;
			private set;
		}
#endif
		
		/// <summary>
		/// 实例化微博操作类
		/// </summary>
		/// <param name="oauth">OAuth实例</param>
		public Client(OAuth oauth)
		{
			this.OAuth = oauth;
#if NET40
			API = new Interface.InterfaceSelector(this);
#else
			API = new Interface.EntityInterfaces(this);
#endif
		}

		/// <summary>
		/// 用POST方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string PostCommand(string command, params WeiboParameter[] parameters)
		{
			return PostCommand(command, false, parameters);
		}
		/// <summary>
		/// 用POST方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string PostCommand(string command, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			List<WeiboParameter> list = new List<WeiboParameter>();
			foreach (var item in parameters)
			{
				list.Add(new WeiboStringParameter(item.Key, item.Value));
			}
			return PostCommand(command, false, list.ToArray());
		}
		/// <summary>
		/// 用POST方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="multi">是否使用multipart模式传输数据。一般上传图片什么的才开启这个参数。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string PostCommand(string command, bool multi = true, params WeiboParameter[] parameters)
		{
			return Http(command, RequestMethod.Post, multi, parameters);	
		}
		/// <summary>
		/// 用GET方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string GetCommand(string command, params WeiboParameter[] parameters)
		{
			return Http(command, RequestMethod.Get, false, parameters);	
		}
		/// <summary>
		/// 用GET方式发送微博指令
		/// </summary>
		/// <param name="command">微博命令。命令例如：statuses/public_timeline。详见官方API文档。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string GetCommand(string command, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			List<WeiboParameter> list = new List<WeiboParameter>();
			foreach (var item in parameters)
			{ 
				list.Add(new WeiboStringParameter(item.Key,item.Value));
			}
			return Http(command, RequestMethod.Get, false, list.ToArray());
		}

		private string Http(string command, RequestMethod method, bool multi, params WeiboParameter[] parameters)
		{
			string url = string.Empty;

			if (command.StartsWith("http://") || command.StartsWith("https://"))
			{
				url = command;
			}
			else
			{
				url = string.Format("{0}{1}.json", BASE_URL, command);
			}
			return OAuth.Request(url, method, multi, parameters);
		}
	}
}
