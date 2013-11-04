using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	/// <summary>
	/// 微博API接口封装基类
	/// </summary>
	internal abstract class WeiboAPI
	{
		/// <summary>
		/// 操作类
		/// </summary>
		protected Client Client;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类实例</param>
		internal WeiboAPI(Client client)
		{
			this.Client = client;
		}
	}
}
