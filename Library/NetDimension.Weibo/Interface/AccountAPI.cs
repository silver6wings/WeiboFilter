using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class AccountAPI : WeiboAPI
	{
		public AccountAPI(Client client)
			: base(client)
		{

		}

		/// <summary>
		/// 获取当前登录用户的隐私设置 
		/// </summary>
		/// <returns>JSON</returns>
		public string GetPrivacy()
		{
			return (Client.GetCommand("account/get_privacy"));
		}

		/// <summary>
		/// 获取所有的学校列表 
		/// </summary>
		/// <param name="province">省份范围，省份ID。</param>
		/// <param name="city">城市范围，城市ID。</param>
		/// <param name="area">区域范围，区ID。</param>
		/// <param name="type">学校类型，1：大学、2：高中、3：中专技校、4：初中、5：小学，默认为1。</param>
		/// <param name="capital">学校首字母，默认为A。 </param>
		/// <param name="keyword">学校名称关键字。</param>
		/// <param name="count">返回的记录条数，默认为10。</param>
		/// <returns>JSON</returns>
		public string SchoolList(string province = "", string city = "", string area = "", string type = "1", string capital = "", string keyword = "", int count = 10)
		{
			var p = new List<WeiboParameter>{
				string.IsNullOrEmpty(capital)?new WeiboStringParameter("keyword", keyword): new WeiboStringParameter("capital", capital),
				new WeiboStringParameter("count", count)
			};

			if (!string.IsNullOrEmpty(province))
			{
				p.Add(new WeiboStringParameter("province", province));
			}

			if (!string.IsNullOrEmpty(city))
			{
				p.Add(new WeiboStringParameter("city", city));
			}

			if (!string.IsNullOrEmpty(area))
			{
				p.Add(new WeiboStringParameter("area", area));
			}

			return (Client.GetCommand("account/profile/school_list",
				p.ToArray()));
		}

		/// <summary>
		/// 获取当前登录用户的API访问频率限制情况 
		/// </summary>
		/// <returns>JSON</returns>
		public string RateLimitStatus()
		{
			return (Client.GetCommand("account/rate_limit_status"));
		}

		/// <summary>
		/// OAuth授权之后，获取授权用户的UID 
		/// </summary>
		/// <returns>JSON</returns>
		public string GetUID()
		{
			return (Client.GetCommand("account/get_uid"));
		}

		/// <summary>
		/// 退出登录
		/// </summary>
		/// <returns>JSON</returns>
		public string EndSession()
		{
			return (Client.GetCommand("account/end_session"));
		}

		/// <summary>
		/// 验证昵称是否可用，并给予建议昵称 
		/// </summary>
		/// <param name="nickname">需要验证的昵称。4-20个字符，支持中英文、数字、"_"或减号。必须做URLEncode，采用UTF-8编码。 </param>
		/// <returns>JSON</returns>
		public string VerifyNickname(string nickname)
		{
			return (Client.GetCommand("register/verify_nickname", new WeiboStringParameter("nickname", nickname)));
		}

		/// <summary>
		/// 获取某个用户的各种消息未读数 
		/// </summary>
		/// <param name="uid">需要获取消息未读数的用户UID，必须是当前登录用户。</param>
		/// <param name="callback">JSONP回调函数，用于前端调用返回JS格式的信息。 </param>
		/// <returns></returns>
		public string UnreadCount(string uid, string callback = "")
		{
			return (Client.GetCommand("https://rm.api.weibo.com/2/remind/unread_count.json",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("callback", callback)));
		}

		/// <summary>
		/// 对当前登录用户某一种消息未读数进行清零
		/// </summary>
		/// <param name="type">需要清零未读数的消息项，status：新微博数、follower：新粉丝数、cmt：新评论数、dm：新私信数、mention_status：新提及我的微博数、mention_cmt：新提及我的评论数，一次只能操作一项。 </param>
		/// <returns>JSON</returns>
		public string SetCount(ResetCountType type)
		{
			return (Client.PostCommand("https://rm.api.weibo.com/2/remind/set_count.json", new WeiboStringParameter("type", type)));
		}
	}
}
