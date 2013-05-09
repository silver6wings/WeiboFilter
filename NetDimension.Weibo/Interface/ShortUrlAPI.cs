using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class ShortUrlAPI: WeiboAPI
	{
		public ShortUrlAPI(Client client)
			: base(client)
		{

		}

		/// <summary>
		/// 获取短链接的总点击数 
		/// </summary>
		/// <param name="url_short">需要取得点击数的短链接</param>
		/// <returns></returns>
		public string Clicks(string url_short)
		{
			return (Client.GetCommand("short_url/clicks", new WeiboStringParameter("url_short", url_short)));
		}
		/// <summary>
		/// 获取一个短链接点击的referer来源和数量
		/// </summary>
		/// <param name="url_short">需要取得点击来源的短链接</param>
		/// <returns></returns>
		public string Referers(string url_short)
		{
			return (Client.GetCommand("short_url/referers", new WeiboStringParameter("url_short", url_short)));
		}
		/// <summary>
		/// 获取一个短链接点击的地区来源和数量 
		/// </summary>
		/// <param name="url_short">需要取得点击地区的短链接</param>
		/// <returns></returns>
		public string Locations(string url_short)
		{
			return (Client.GetCommand("short_url/locations", new WeiboStringParameter("url_short", url_short)));
		}
		/// <summary>
		/// 批量获取短链接的富内容信息
		/// </summary>
		/// <param name="url_short">需要获取富内容信息的短链接</param>
		/// <returns></returns>
		public string Info(params string[] url_short)
		{
			List<WeiboStringParameter> parameters = new List<WeiboStringParameter>();

			foreach (string u in url_short)
			{
				parameters.Add(new WeiboStringParameter("url_short", u));
			}

			return (Client.GetCommand("short_url/info", parameters.ToArray()));
		}

		/// <summary>
		/// 将一个或多个长链接转换成短链接 
		/// </summary>
		/// <param name="url_long">需要转换的长链接，需要URLencoded，最多不超过20个。 </param>
		/// <returns></returns>
		public string Shorten(params string[] url_long)
		{
			List<WeiboStringParameter> parameters = new List<WeiboStringParameter>();

			foreach (string u in url_long)
			{
				parameters.Add(new WeiboStringParameter("url_long", u));
			}
			return (Client.GetCommand("short_url/shorten", parameters.ToArray()));
		}

		/// <summary>
		/// 将一个或多个短链接还原成原始的长链接 
		/// </summary>
		/// <param name="url_short">需要还原的短链接，需要URLencoded，最多不超过20个 </param>
		/// <returns></returns>
		public string Expand(params string[] url_short)
		{
			List<WeiboStringParameter> parameters = new List<WeiboStringParameter>();

			foreach (string u in url_short)
			{
				parameters.Add(new WeiboStringParameter("url_short", u));
			}
			return (Client.GetCommand("short_url/expand", parameters.ToArray()));

		}


		/// <summary>
		/// 取得一个短链接在微博上的微博分享数（包含原创和转发的微博） 
		/// </summary>
		/// <param name="url_short">需要取得分享数的短链接</param>
		/// <returns></returns>
		public string ShareCounts(string[] url_short)
		{
			List<WeiboStringParameter> parameters = new List<WeiboStringParameter>();

			foreach (string u in url_short)
			{
				parameters.Add(new WeiboStringParameter("url_short", u));
			}

			return (Client.GetCommand("short_url/share/counts", parameters.ToArray()));
		}

		/// <summary>
		/// 取得包含指定单个短链接的最新微博内容 
		/// </summary>
		/// <param name="urlShort">需要取得关联微博内容的短链接</param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0 </param>
		/// <param name="maxID">指定此参数，则返回ID小于或等于max_id的微博，默认为0 </param>
		/// <param name="count">可选参数，返回结果的页序号，有分页限制</param>
		/// <param name="page">可选参数，每次返回的最大记录数（即页面大小），不大于200 </param>
		/// <returns></returns>
		public string ShareStatuses(string urlShort, string sinceID = "", string maxID = "", int count = 20, int page = 1)
		{
			List<WeiboStringParameter> parameters = new List<WeiboStringParameter>();
			parameters.Add(new WeiboStringParameter("url_short", urlShort));

			if (!string.IsNullOrEmpty(sinceID))
				parameters.Add(new WeiboStringParameter("since_id", sinceID));
			if (!string.IsNullOrEmpty(maxID))
				parameters.Add(new WeiboStringParameter("max_id", maxID));

			parameters.Add(new WeiboStringParameter("count", count));
			parameters.Add(new WeiboStringParameter("page", page));

			return (Client.GetCommand("short_url/share/statuses", parameters.ToArray()));
		}

		/// <summary>
		/// 取得一个短链接在微博上的微博评论数 
		/// </summary>
		/// <param name="url_short">需要取得评论数的短链接</param>
		/// <returns></returns>
		public string CommentCounts(string[] url_short)
		{
			List<WeiboStringParameter> parameters = new List<WeiboStringParameter>();

			foreach (string u in url_short)
			{
				parameters.Add(new WeiboStringParameter("url_short", u));
			}
			return (Client.GetCommand("short_url/comment/counts", parameters.ToArray()));
		}

		/// <summary>
		/// 取得包含指定单个短链接的最新微博评论内容 
		/// </summary>
		/// <param name="urlShort">需要取得关联微博评论内容的短链接</param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0 </param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的评论，默认为0 </param>
		/// <param name="count">可选参数，每次返回的最大记录数（即页面大小），不大于200 </param>
		/// <param name="page">可选参数，返回结果的页序号，有分页限制</param>
		/// <returns></returns>
		public string CommentComments(string urlShort, string sinceID = "", string maxID = "", int count = 20, int page = 1)
		{
			List<WeiboStringParameter> parameters = new List<WeiboStringParameter>();
			parameters.Add(new WeiboStringParameter("url_short", urlShort));

			if (!string.IsNullOrEmpty(sinceID))
				parameters.Add(new WeiboStringParameter("since_id", sinceID));
			if (!string.IsNullOrEmpty(maxID))
				parameters.Add(new WeiboStringParameter("max_id", maxID));

			parameters.Add(new WeiboStringParameter("count", count));
			parameters.Add(new WeiboStringParameter("page", page));

			return (Client.GetCommand("short_url/comment/comments", parameters.ToArray()));
		}

	}
}
