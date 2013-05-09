using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class SuggestionAPI: WeiboAPI
	{
		public SuggestionAPI(Client client)
			: base(client)
		{

		}

				/// <summary>
		/// 获取系统推荐用户 
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		public string HotUsers(HotUserCatagory category = HotUserCatagory.@default)
		{
			return (Client.GetCommand("suggestions/users/hot",
				new WeiboStringParameter("category", category)));
		}
		/// <summary>
		/// 获取用户可能感兴趣的人
		/// </summary>
		/// <param name="count"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		public string MayInterestedUsers(int count = 10, int page = 1)
		{
			return (Client.GetCommand("suggestions/users/may_interested",
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 根据微博内容推荐用户 
		/// </summary>
		/// <param name="content"></param>
		/// <param name="num"></param>
		/// <returns></returns>
		public string UsersByStatus(string content, int num = 10)
		{
			return (Client.GetCommand("suggestions/users/by_status",
					new WeiboStringParameter("content", content),
					new WeiboStringParameter("num", num)));
		}
		/// <summary>
		/// 获取微博精选推荐
		/// </summary>
		/// <param name="type">微博精选分类，1：娱乐、2：搞笑、3：美女、4：视频、5：星座、6：各种萌、7：时尚、8：名车、9：美食、10：音乐。 </param>
		/// <param name="isPic">是否返回图片精选微博，0：全部、1：图片微博。 </param>
		/// <param name="count">单页返回的记录条数，默认为20。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public string HotStatuses(int type = 1, bool isPic = false, int count = 20, int page = 1)
		{
			return (Client.GetCommand("suggestions/statuses/hot",
					new WeiboStringParameter("type", type),
					new WeiboStringParameter("isPic", isPic),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 当前登录用户的friends_timeline微博按兴趣推荐排序 
		/// </summary>
		/// <param name="section">排序时间段，距现在n秒内的微博参加排序，最长支持24小时。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public string ReorderStatuses(int section, int count = 50, int page = 1)
		{
			return (Client.GetCommand("suggestions/statuses/reorder",
					new WeiboStringParameter("section", section),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 主Feed微博按兴趣推荐排序的微博ID 
		/// </summary>
		/// <param name="section">排序时间段，距现在n秒内的微博参加排序，最长支持24小时。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public string ReorderStatusIDs(int section, int count = 50, int page = 1)
		{
			return (Client.GetCommand("suggestions/statuses/reorder/ids",
					new WeiboStringParameter("section", section),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 热门收藏 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		public string HotFavorites(int count = 20, int page = 1)
		{
			return (Client.GetCommand("suggestions/favorites/hot",
						new WeiboStringParameter("count", count),
						new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 把某人标识为不感兴趣的人 
		/// </summary>
		/// <param name="uid">不感兴趣的用户的UID。 </param>
		/// <returns></returns>
		public string NotInterestedUsers(string uid)
		{
			return (Client.PostCommand("suggestions/users/not_interested",
						new WeiboStringParameter("uid", uid)));
		}

	}
}
