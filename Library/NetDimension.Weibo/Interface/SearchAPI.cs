using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class SearchAPI: WeiboAPI
	{
		public SearchAPI(Client client)
			: base(client)
		{

		}

		/// <summary>
		/// 搜索用户时的联想搜索建议 
		/// </summary>
		/// <param name="q">搜索的关键字</param>
		/// <param name="count">返回的记录条数，默认为10</param>
		/// <returns></returns>
		public string Users(string q, int count = 10)
		{
			return (Client.GetCommand("search/suggestions/users",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("count", count)));
		}
		/// <summary>
		/// 搜索微博时的联想搜索建议 
		/// </summary>
		/// <param name="q">搜索的关键字</param>
		/// <param name="count">返回的记录条数，默认为10</param>
		/// <returns></returns>
		public string Statuses(string q, int count = 10)
		{
			return (Client.GetCommand("search/suggestions/statuses",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("count", count)));
		}
		/// <summary>
		/// 搜索学校时的联想搜索建议 
		/// </summary>
		/// <param name="q">搜索的关键字</param>
		/// <param name="count">返回的记录条数，默认为10。 </param>
		/// <param name="type">学校类型，0：全部、1：大学、2：高中、3：中专技校、4：初中、5：小学，默认为0。 </param>
		/// <returns></returns>
		public string Schools(string q, int count = 10, int type = 0)
		{
			return (Client.GetCommand("search/suggestions/schools",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("type", type)));
		}
		/// <summary>
		/// 搜索公司时的联想搜索建议 
		/// </summary>
		/// <param name="q">搜索的关键字</param>
		/// <param name="count">返回的记录条数，默认为10</param>
		/// <returns></returns>
		public string Companies(string q, int count = 10)
		{
			return (Client.GetCommand("search/suggestions/companies",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("count", count)));
		}
		/// <summary>
		/// 搜索应用时的联想搜索建议 
		/// </summary>
		/// <param name="q">搜索的关键字</param>
		/// <param name="count">返回的记录条数，默认为10</param>
		/// <returns></returns>
		public string Apps(string q, int count = 10)
		{
			return (Client.GetCommand("search/suggestions/apps",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("count", count)));
		}
		/// <summary>
		/// @用户时的联想建议 
		/// </summary>
		/// <param name="q">搜索的关键字</param>
		/// <param name="count">返回的记录条数，默认为10，粉丝最多1000，关注最多2000。 </param>
		/// <param name="type">联想类型，0：关注、1：粉丝。</param>
		/// <param name="range">联想范围，0：只联想关注人、1：只联想关注人的备注、2：全部，默认为2。</param>
		/// <returns></returns>
		public string AtUsers(string q, int count = 10, int type = 0, int range = 2)
		{
			return (Client.GetCommand("search/suggestions/at_users",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("type", type),
				new WeiboStringParameter("range", range)));
		}
		/// <summary>
		/// 搜索某一话题下的微博 
		/// </summary>
		/// <param name="q">搜索的话题关键字</param>
		/// <param name="count">单页返回的记录条数，默认为10，最大为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public string Topics(string q, int count = 10, int page = 1)
		{
			return (Client.GetCommand("search/topics",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page)));
		}

	}
}
