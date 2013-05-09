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
	/// ShortUrl接口
	/// </summary>
	public class ShortUrlInterface: WeiboInterface
	{
		ShortUrlAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public ShortUrlInterface(Client client)
			: base(client)
		{
			api = new ShortUrlAPI(client);
		}
		/// <summary>
		/// 获取短链接的总点击数 
		/// </summary>
		/// <param name="url_short">需要取得点击数的短链接</param>
		/// <returns></returns>
		public IEnumerable<Entities.shortUrl.Clicks> Clicks(string url_short)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.shortUrl.Clicks>>(JObject.Parse(api.Clicks(url_short))["urls"].ToString());
		}
		/// <summary>
		/// 获取一个短链接点击的referer来源和数量
		/// </summary>
		/// <param name="url_short">需要取得点击来源的短链接</param>
		/// <returns></returns>
		public Entities.shortUrl.Referers Referers(string url_short)
		{
			return JsonConvert.DeserializeObject<Entities.shortUrl.Referers>(api.Referers(url_short));
		}
		/// <summary>
		/// 获取一个短链接点击的地区来源和数量 
		/// </summary>
		/// <param name="url_short">需要取得点击地区的短链接</param>
		/// <returns></returns>
		public Entities.shortUrl.Locations Locations(string url_short)
		{
			return JsonConvert.DeserializeObject<Entities.shortUrl.Locations>(api.Locations(url_short));
		}
		/// <summary>
		/// 批量获取短链接的富内容信息
		/// </summary>
		/// <param name="url_short">需要获取富内容信息的短链接</param>
		/// <returns></returns>
		public IEnumerable<Entities.shortUrl.Info> Info(params string[] url_short)
		{

			return JsonConvert.DeserializeObject<IEnumerable<Entities.shortUrl.Info>>(JObject.Parse(api.Info(url_short))["urls"].ToString());
		}

		/// <summary>
		/// 将一个或多个长链接转换成短链接 
		/// </summary>
		/// <param name="url_long">需要转换的长链接，需要URLencoded，最多不超过20个。 </param>
		/// <returns></returns>
		public IEnumerable<Entities.shortUrl.Url> Shorten(params string[] url_long)
		{

			return JsonConvert.DeserializeObject<IEnumerable<Entities.shortUrl.Url>>(JObject.Parse(api.Shorten(url_long))["urls"].ToString());
		}

		/// <summary>
		/// 将一个或多个短链接还原成原始的长链接 
		/// </summary>
		/// <param name="url_short">需要还原的短链接，需要URLencoded，最多不超过20个 </param>
		/// <returns></returns>
		public IEnumerable<Entities.shortUrl.Url> Expand(params string[] url_short)
		{

			return JsonConvert.DeserializeObject<IEnumerable<Entities.shortUrl.Url>>(JObject.Parse(api.Expand(url_short))["urls"].ToString());

		}


		/// <summary>
		/// 取得一个短链接在微博上的微博分享数（包含原创和转发的微博） 
		/// </summary>
		/// <param name="url_short">需要取得分享数的短链接</param>
		/// <returns></returns>
		public IEnumerable<Entities.shortUrl.ShareCounts> ShareCounts(string[] url_short)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.shortUrl.ShareCounts>>(JObject.Parse(api.ShareCounts(url_short))["urls"].ToString());
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
		public Entities.shortUrl.ShareStatuses ShareStatuses(string urlShort, string sinceID = "", string maxID = "", int count = 20, int page = 1)
		{
			return JsonConvert.DeserializeObject<Entities.shortUrl.ShareStatuses>(api.ShareStatuses(urlShort, sinceID, maxID, count, page));
		}

		/// <summary>
		/// 取得一个短链接在微博上的微博评论数 
		/// </summary>
		/// <param name="url_short">需要取得评论数的短链接</param>
		/// <returns></returns>
		public IEnumerable< Entities.shortUrl.CommentCount> CommentCounts(string[] url_short)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.shortUrl.CommentCount>>(JObject.Parse(api.CommentCounts(url_short))["urls"].ToString());
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
		public Entities.shortUrl.CommentComments CommentComments(string urlShort, string sinceID = "", string maxID = "", int count = 20, int page = 1)
		{
			return JsonConvert.DeserializeObject<Entities.shortUrl.CommentComments>(api.CommentComments(urlShort, sinceID, maxID, count, page));
		}

	}
}
