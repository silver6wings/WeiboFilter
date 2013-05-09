using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class UserAPI: WeiboAPI
	{
		public UserAPI(Client client)
			: base(client)
		{

		}

		/// <summary>
		/// 获取用户信
		/// </summary>
		/// <param name="uid">需要查询的用户ID。 </param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <returns></returns>
		public string Show(string uid = "", string screenName = "")
		{
			return (Client.GetCommand("users/show",
				string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid)));
		}
		/// <summary>
		/// 通过个性化域名获取用户资料以及用户最新的一条微博 
		/// </summary>
		/// <param name="domain">需要查询的个性化域名。 </param>
		/// <returns></returns>
		public string ShowByDomain(string domain)
		{
			return (Client.GetCommand("users/domain_show", new WeiboStringParameter("domain", domain)));
		}
		/// <summary>
		/// 批量获取用户的粉丝数、关注数、微博数
		/// </summary>
		/// <param name="uids"></param>
		/// <returns></returns>
		public string Counts(params string[] uids)
		{
			return (Client.GetCommand("users/counts", new WeiboStringParameter("uids", string.Join(",", uids))));
		}

	}
}
