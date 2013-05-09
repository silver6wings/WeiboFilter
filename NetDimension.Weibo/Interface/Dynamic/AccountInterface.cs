using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Codeplex.Data;

namespace NetDimension.Weibo.Interface.Dynamic
{
	/// <summary>
	/// Account接口
	/// </summary>
	public class AccountInterface: WeiboInterface
	{
		AccountAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public AccountInterface(Client client)
			: base(client)
		{
			api = new AccountAPI(client);
		}

		/// <summary>
		/// 获取当前登录用户的隐私设置 
		/// </summary>
		/// <returns>JSON</returns>
		public dynamic GetPrivacy()
		{
			return DynamicJson.Parse(api.GetPrivacy());
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
		public dynamic SchoolList(string province = "", string city = "", string area = "", string type = "1", string capital = "", string keyword = "", int count = 10)
		{

			return DynamicJson.Parse(api.SchoolList(province,city,area,type,capital,keyword,count));
		}

		/// <summary>
		/// 获取当前登录用户的API访问频率限制情况 
		/// </summary>
		/// <returns>JSON</returns>
		public dynamic RateLimitStatus()
		{
			return DynamicJson.Parse(api.RateLimitStatus());
		}

		/// <summary>
		/// OAuth授权之后，获取授权用户的UID 
		/// </summary>
		/// <returns>JSON</returns>
		public dynamic GetUID()
		{
			return DynamicJson.Parse(api.GetUID());
		}

		/// <summary>
		/// 退出登录
		/// </summary>
		/// <returns>JSON</returns>
		public dynamic EndSession()
		{
			return DynamicJson.Parse(api.EndSession());
		}

		/// <summary>
		/// 验证昵称是否可用，并给予建议昵称 
		/// </summary>
		/// <param name="nickname">需要验证的昵称。4-20个字符，支持中英文、数字、"_"或减号。必须做URLEncode，采用UTF-8编码。 </param>
		/// <returns>JSON</returns>
		public dynamic VerifyNickname(string nickname)
		{
			return DynamicJson.Parse(api.VerifyNickname(nickname));
		}

		/// <summary>
		/// 获取某个用户的各种消息未读数 
		/// </summary>
		/// <param name="uid">需要获取消息未读数的用户UID，必须是当前登录用户。</param>
		/// <param name="callback">JSONP回调函数，用于前端调用返回JS格式的信息。 </param>
		/// <returns></returns>
		public dynamic UnreadCount(string uid,string callback="")
		{
			return DynamicJson.Parse(api.UnreadCount(uid,callback));
		}

		/// <summary>
		/// 对当前登录用户某一种消息未读数进行清零
		/// </summary>
		/// <param name="type">需要清零未读数的消息项，status：新微博数、follower：新粉丝数、cmt：新评论数、dm：新私信数、mention_status：新提及我的微博数、mention_cmt：新提及我的评论数，一次只能操作一项。 </param>
		/// <returns>JSON</returns>
		public dynamic SetCount(ResetCountType type)
		{
			return DynamicJson.Parse(api.SetCount(type));
		}

	}
}
