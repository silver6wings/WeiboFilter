using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.Weibo.Interface
{
	/// <summary>
	/// 微博API接口封装基类
	/// </summary>
	public abstract class WeiboInterface
	{
		/// <summary>
		/// 操作类
		/// </summary>
		protected Client Client;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类实例</param>
		public WeiboInterface(Client client)
		{
			this.Client = client;
		}
	}
}
