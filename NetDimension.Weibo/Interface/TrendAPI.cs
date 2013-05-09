using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class TrendAPI: WeiboAPI
	{
		public TrendAPI(Client client)
			: base(client)
		{

		}

		/// <summary>
		/// 获取某人话题 
		/// </summary>
		/// <param name="uid"></param>
		/// <param name="count"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		public string Trends(string uid, int count = 10, int page = 1)
		{
			return (Client.GetCommand("trends",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 是否关注某话题 
		/// </summary>
		/// <param name="trendName"></param>
		/// <returns></returns>
		public string IsFollow(string trendName)
		{
			return (Client.GetCommand("trends/is_follow",
				new WeiboStringParameter("trend_name", trendName)));
		}

		/// <summary>
		/// 返回最近一小时内的热门话题。 
		/// </summary>
		/// <param name="baseApp">是否基于当前应用来获取数据。true表示基于当前应用来获取数据。 </param>
		/// <returns></returns>
		public string Hourly(bool baseApp = false)
		{
			return (Client.GetCommand("trends/hourly",
				new WeiboStringParameter("base_app", baseApp)));
		}

		/// <summary>
		/// 返回最近一天内的热门话题。 
		/// </summary>
		/// <param name="baseApp">是否基于当前应用来获取数据。true表示基于当前应用来获取数据。 </param>
		/// <returns></returns>
		public string Daily(bool baseApp = false)
		{
			return (Client.GetCommand("trends/daily",
				new WeiboStringParameter("base_app", baseApp)));
		}

		/// <summary>
		/// 返回最近一周内的热门话题。 
		/// </summary>
		/// <param name="baseApp">是否基于当前应用来获取数据。true表示基于当前应用来获取数据。 </param>
		/// <returns></returns>
		public string Weekly(bool baseApp = false)
		{
			return (Client.GetCommand("trends/weekly",
				new WeiboStringParameter("base_app", baseApp)));
		}
		/// <summary>
		/// 关注某话题 
		/// </summary>
		/// <param name="trendName"></param>
		/// <returns></returns>
		public string Follow(string trendName)
		{
			return (Client.PostCommand("trends/follow",
				new WeiboStringParameter("trend_name", trendName)));
		}
		/// <summary>
		/// 取消关注的某一个话题 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public string Destroy(string id)
		{
			return (Client.PostCommand("trends/destroy",
				  new WeiboStringParameter("trend_id", id)));

		}


	}
}
