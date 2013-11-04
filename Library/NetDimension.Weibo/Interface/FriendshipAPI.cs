using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class FriendshipAPI: WeiboAPI
	{
		public FriendshipAPI(Client client)
			: base(client)
		{

		}
		/// <summary>
		/// 获取用户的关注列表 
		/// </summary>
		/// <param name="uid">需要查询的用户UID。 </param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
		/// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
		/// <returns></returns>
		public string Friends(string uid = "", string screenName = "", int count = 50, int cursor = 0, bool trimStatus=true)
		{
			return (Client.GetCommand("friendships/friends",
				string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("cursor", cursor),
				new WeiboStringParameter("trim_status ", trimStatus)));
		}
		/// <summary>
		/// 获取用户关注的用户UID列表
		/// </summary>
		/// <param name="uid">需要查询的用户UID。 </param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <param name="count">单页返回的记录条数，默认为500，最大不超过5000。 </param>
		/// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
		/// <returns></returns>
		public string FriendIDs(string uid = "", string screenName = "", int count = 50, int cursor = 0)
		{
			return (Client.GetCommand("friendships/friends/ids",
					string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("cursor", cursor)));
		}
		/// <summary>
		/// 获取两个用户之间的共同关注人列表 
		/// </summary>
		/// <param name="uid">需要获取共同关注关系的用户UID。</param>
		/// <param name="suid">需要获取共同关注关系的用户UID，默认为当前登录用户。</param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public string FriendsInCommon(string uid = "", string suid = "", int count = 50, int page = 1)
		{
			return (Client.GetCommand("friendships/friends/in_common",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("suid", suid),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 获取用户的双向关注列表，即互粉列表 
		/// </summary>
		/// <param name="uid">需要获取双向关注列表的用户UID。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。</param>
		/// <returns></returns>
		public string FriendsOnBilateral(string uid, int count = 50, int page = 1, bool sort = false)
		{
			return (Client.GetCommand("friendships/friends/bilateral",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("sort", sort)));
		}
		/// <summary>
		/// 获取用户双向关注的用户ID列表，即互粉UID列表 
		/// </summary>
		/// <param name="uid">需要获取双向关注列表的用户UID。</param>
		/// <param name="count">单页返回的记录条数，默认为50，最大不超过2000。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。 </param>
		/// <returns></returns>
		public string FriendsOnBilateralIDs(string uid, int count = 50, int page = 1, bool sort = false)
		{
			return (Client.GetCommand("friendships/friends/bilateral/ids",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("sort", sort)));
		}
		/// <summary>
		/// 获取用户的粉丝列表 
		/// </summary>
		/// <param name="uid">需要查询的用户UID。 </param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
		/// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
		/// <returns></returns>
		public string Followers(string uid = "", string screenName = "", int count = 50, int cursor = 0,bool trimStatus=true)
		{
			return (Client.GetCommand("friendships/followers",
				string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("cursor", cursor),
				new WeiboStringParameter("trim_status ", trimStatus)));
		}
		/// <summary>
		/// 获取用户粉丝的用户UID列表 
		/// </summary>
		/// <param name="uid">需要查询的用户UID。</param>
		/// <param name="screenName">需要查询的用户昵称。 </param>
		/// <param name="count">单页返回的记录条数，默认为500，最大不超过5000。</param>
		/// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。 </param>
		/// <returns></returns>
		public string FollowerIDs(string uid = "", string screenName = "", int count = 50, int cursor = 0)
		{
			return (Client.GetCommand("friendships/followers/ids",
				string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("cursor", cursor)));
		}
		/// <summary>
		/// 获取用户的活跃粉丝列表
		/// </summary>
		/// <param name="uid">需要查询的用户UID。 </param>
		/// <param name="count">返回的记录条数，默认为20，最大不超过200。 </param>
		/// <returns></returns>
		public string FollowersInActive(string uid, int count = 20)
		{
			return (Client.GetCommand("friendships/followers/active",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("count", count)));

		}
		/// <summary>
		/// 获取当前登录用户的关注人中又关注了指定用户的用户列表
		/// </summary>
		/// <param name="uid">指定的关注目标用户UID。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public string FriendsChain(string uid, int count = 50, int page = 1)
		{
			return (Client.GetCommand("friendships/friends_chain/followers",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 获取两个用户之间的详细关注关系情况
		/// </summary>
		/// <param name="sourceID">源用户的UID。</param>
		/// <param name="sourceScreenName">源用户的微博昵称。 </param>
		/// <param name="targetID">目标用户的UID。 </param>
		/// <param name="targetScreenName">目标用户的微博昵称。 </param>
		/// <returns></returns>
		public string Show(string sourceID = "", string sourceScreenName = "", string targetID = "", string targetScreenName = "")
		{
			return (Client.GetCommand("friendships/show",
				string.IsNullOrEmpty(sourceID) ? new WeiboStringParameter("source_screen_name", sourceScreenName) : new WeiboStringParameter("source_id", sourceID),
				string.IsNullOrEmpty(targetID) ? new WeiboStringParameter("target_screen_name", targetScreenName) : new WeiboStringParameter("target_id", targetID)));
		}
		/// <summary>
		/// 关注一个用户 
		/// </summary>
		/// <param name="uid">需要关注的用户ID。</param>
		/// <param name="screenName">需要关注的用户昵称。 </param>
		/// <returns></returns>
		public string Create(string uid = "", string screenName = "")
		{
			return (Client.PostCommand("friendships/create",
				string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid)));
		}
		/// <summary>
		/// 取消关注一个用户 
		/// </summary>
		/// <param name="uid">需要取消关注的用户ID。</param>
		/// <param name="screenName">需要取消关注的用户昵称。 </param>
		/// <returns></returns>
		public string Destroy(string uid = "", string screenName = "")
		{
			return (Client.PostCommand("friendships/destroy",
				string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid)));
		}
		/// <summary>
		/// 更新当前登录用户所关注的某个好友的备注信息 
		/// </summary>
		/// <param name="uid">需要修改备注信息的用户UID。 </param>
		/// <param name="remark">备注信息</param>
		/// <returns></returns>
		public string UpdateRemark(string uid, string remark)
		{
			return (Client.PostCommand("friendships/remark/update",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("remark", remark)));
		}


	}
}
