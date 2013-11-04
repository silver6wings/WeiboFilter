using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Codeplex.Data;


namespace NetDimension.Weibo.Interface.Dynamic
{
	/// <summary>
	/// User接口
	/// </summary>
	public class UserInterface: WeiboInterface
	{
		UserAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类实例</param>
		public UserInterface(Client client)
			: base(client)
		{
			api = new UserAPI(client);
		}
		/// <summary>
		/// 获取用户信
		/// </summary>
		/// <param name="uid">需要查询的用户ID。 </param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <returns></returns>
		public dynamic Show(string uid = "", string screenName = "")
		{
			return DynamicJson.Parse(api.Show(uid,screenName));
		}
		/// <summary>
		/// 通过个性化域名获取用户资料以及用户最新的一条微博 
		/// </summary>
		/// <param name="domain">需要查询的个性化域名。 </param>
		/// <returns></returns>
		public dynamic ShowByDomain(string domain)
		{
			return DynamicJson.Parse(api.ShowByDomain(domain));
		}
		/// <summary>
		/// 批量获取用户的粉丝数、关注数、微博数
		/// </summary>
		/// <param name="uids"></param>
		/// <returns></returns>
		public dynamic Counts(params string[] uids)
		{
			return DynamicJson.Parse(api.Counts(uids));
		}
	}
}
