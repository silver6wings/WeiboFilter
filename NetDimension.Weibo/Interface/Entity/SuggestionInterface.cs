using System;
using System.Collections.Generic;
using NetDimension.Weibo.Entities;
using System.Text;
using System.Web;
using NetDimension.Json;
using NetDimension.Json.Linq;

namespace NetDimension.Weibo.Interface.Entity
{
	/// <summary>
	/// Suggestion接口
	/// </summary>
	public class SuggestionInterface: WeiboInterface
	{
		SuggestionAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public SuggestionInterface(Client client)
			: base(client)
		{
			api = new SuggestionAPI(client);
		}

		/// <summary>
		/// 获取系统推荐用户 
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		public IEnumerable<Entities.user.Entity> HotUsers(HotUserCatagory category = HotUserCatagory.@default)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.user.Entity>>(api.HotUsers(category));
		}
		/// <summary>
		/// 获取用户可能感兴趣的人
		/// </summary>
		/// <param name="count"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		public string MayInterestedUsers(int count = 10, int page = 1)
		{
			return api.MayInterestedUsers(count, page);
		}
		/// <summary>
		/// 根据微博内容推荐用户 
		/// </summary>
		/// <param name="content"></param>
		/// <param name="num"></param>
		/// <returns></returns>
		public IEnumerable<Entities.user.Entity> UsersByStatus(string content, int num = 10)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.user.Entity>>(JObject.Parse(api.UsersByStatus(content, num))["users"].ToString());
		}
		/// <summary>
		/// 获取微博精选推荐
		/// </summary>
		/// <param name="type">微博精选分类，1：娱乐、2：搞笑、3：美女、4：视频、5：星座、6：各种萌、7：时尚、8：名车、9：美食、10：音乐。 </param>
		/// <param name="isPic">是否返回图片精选微博，0：全部、1：图片微博。 </param>
		/// <param name="count">单页返回的记录条数，默认为20。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public IEnumerable<Entities.status.Entity> HotStatuses(int type = 1, bool isPic = false, int count = 20, int page = 1)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.status.Entity>>(JObject.Parse(api.HotStatuses(type, isPic, count, page))["statuses"].ToString());
		}
		/// <summary>
		/// 当前登录用户的friends_timeline微博按兴趣推荐排序 
		/// </summary>
		/// <param name="section">排序时间段，距现在n秒内的微博参加排序，最长支持24小时。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public IEnumerable<Entities.status.Entity> ReorderStatuses(int section, int count = 50, int page = 1)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.status.Entity>>(JObject.Parse(api.ReorderStatuses(section, count, page))["statuses"].ToString());
		}
		/// <summary>
		/// 主Feed微博按兴趣推荐排序的微博ID 
		/// </summary>
		/// <param name="section">排序时间段，距现在n秒内的微博参加排序，最长支持24小时。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public Entities.status.IDs ReorderStatusIDs(int section, int count = 50, int page = 1)
		{
			return JsonConvert.DeserializeObject<Entities.status.IDs>(api.ReorderStatusIDs(section, count, page));
		}
		/// <summary>
		/// 热门收藏 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="page"></param>
		/// <returns></returns>
		public IEnumerable<Entities.status.Entity> HotFavorites(int count = 20, int page = 1)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.status.Entity>>(api.HotFavorites(count, page));
		}
		/// <summary>
		/// 把某人标识为不感兴趣的人 
		/// </summary>
		/// <param name="uid">不感兴趣的用户的UID。 </param>
		/// <returns></returns>
		public Entities.user.Entity NotInterestedUsers(string uid)
		{
			return JsonConvert.DeserializeObject<Entities.user.Entity>(api.NotInterestedUsers(uid));
		}
	}
}
