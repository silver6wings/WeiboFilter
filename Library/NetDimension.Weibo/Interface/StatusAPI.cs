using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class StatusAPI: WeiboAPI
	{
		public StatusAPI(Client client)
			: base(client)
		{

		}
		/// <summary>
		/// 返回最新的公共微博 
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns>dynamic json</returns>
		public string PublicTimeline(int count = 50, int page = 1, bool baseApp = false)
		{
			return (Client.GetCommand("statuses/public_timeline",
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp)));
		}

		/// <summary>
		/// 获取当前登录用户及其所关注用户的最新微博
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="baseApp">否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
		/// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
		/// <returns>dynamic json</returns>
		public string FriendsTimeline(string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return (Client.GetCommand("statuses/friends_timeline",
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp),
				new WeiboStringParameter("feature", feature)));
		}
		/// <summary>
		/// 获取当前登录用户及其所关注用户的最新微博 
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
		/// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。 </param>
		/// <returns></returns>
		public string HomeTimeline(string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return (Client.GetCommand("statuses/home_timeline",
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp),
				new WeiboStringParameter("feature", feature)));
		}
		/// <summary>
		/// 获取当前登录用户及其所关注用户的最新微博的ID
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="baseApp">否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
		/// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
		/// <returns></returns>
		public string FriendsTimelineIDs(string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return (Client.GetCommand("statuses/friends_timeline/ids",
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("base_app", baseApp),
					new WeiboStringParameter("feature", feature)));
		}
		/// <summary>
		/// 获取某个用户最新发表的微博列表 
		/// </summary>
		/// <param name="uid">需要查询的用户ID。 </param>
		/// <param name="screenName">需要查询的用户昵称。</param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
		/// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。 </param>
		/// <param name="trimUser">回值中user信息开关，0：返回完整的user信息、1：user字段仅返回user_id，默认为0。</param>
		/// <returns></returns>
		public string UserTimeline(string uid = "", string screenName = "", string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0, bool trimUser = false)
		{
			return (Client.GetCommand("statuses/user_timeline",
				string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp),
				new WeiboStringParameter("feature", feature),
				new WeiboStringParameter("trim_user", trimUser)));
		}
		/// <summary>
		/// 获取用户发布的微博的ID 
		/// </summary>
		/// <param name="uid">需要查询的用户ID。 </param>
		/// <param name="screenName">需要查询的用户昵称。</param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
		/// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。 </param>
		/// <returns></returns>
		public string UserTimelineIDs(string uid = "", string screenName = "", string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return (Client.GetCommand("statuses/user_timeline/ids",
				string.IsNullOrEmpty(uid) ? new WeiboStringParameter("screen_name", screenName) : new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp),
				new WeiboStringParameter("feature", feature)));
		}
		/// <summary>
		/// 获取指定微博的转发微博列表 
		/// </summary>
		/// <param name="id">需要查询的微博ID。</param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="filterByAuthor">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。 </param>
		/// <returns></returns>
		public string RepostTimeline(string id, string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0)
		{
			return (Client.GetCommand("statuses/repost_timeline",
				new WeiboStringParameter("id", id),
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("filter_by_author", filterByAuthor)));
		}
		/// <summary>
		/// 获取一条原创微博的最新转发微博的ID 
		/// </summary>
		/// <param name="id">需要查询的微博ID。</param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="filterByAuthor">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。 </param>
		/// <returns></returns>
		public string RepostTimelineIDs(string id, string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0)
		{
			return (Client.GetCommand("statuses/repost_timeline/ids",
					new WeiboStringParameter("id", id),
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("filter_by_author", filterByAuthor)));
		}
		/// <summary>
		/// 获取当前用户最新转发的微博列表 
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。 </param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public string RepostByMe(string sinceID = "", string maxID = "", int count = 50, int page = 1)
		{
			return (Client.GetCommand("statuses/repost_by_me",
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 获取最新的提到登录用户的微博列表，即@我的微博 
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="filterByAuthor">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。 </param>
		/// <param name="filterBySource">来源筛选类型，0：全部、1：来自微博、2：来自微群，默认为0。 </param>
		/// <param name="filterByType">原创筛选类型，0：全部微博、1：原创的微博，默认为0。</param>
		/// <returns></returns>
		public string Mentions(string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0, int filterBySource = 0, int filterByType = 0)
		{
			return (Client.GetCommand("statuses/mentions",
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("filter_by_author", filterByAuthor),
					new WeiboStringParameter("filter_by_source", filterBySource),
					new WeiboStringParameter("filter_by_type", filterByType)));
		}
		/// <summary>
		/// 获取@当前用户的最新微博的ID 
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="filterByAuthor">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。 </param>
		/// <param name="filterBySource">来源筛选类型，0：全部、1：来自微博、2：来自微群，默认为0。 </param>
		/// <param name="filterByType">原创筛选类型，0：全部微博、1：原创的微博，默认为0。</param>
		/// <returns></returns>
		public string MentionIDs(string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0, int filterBySource = 0, int filterByType = 0)
		{
			return (Client.GetCommand("statuses/mentions/ids",
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("filter_by_author", filterByAuthor),
					new WeiboStringParameter("filter_by_source", filterBySource),
					new WeiboStringParameter("filter_by_type", filterByType)));
		}
		/// <summary>
		/// 获取双向关注用户的最新微博 
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
		/// <returns></returns>
		public string BilateralTimeline(string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return (Client.GetCommand("statuses/bilateral_timeline",
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("base_app", baseApp),
					new WeiboStringParameter("feature", feature)));
		}
		/// <summary>
		/// 根据微博ID获取单条微博内容 
		/// </summary>
		/// <param name="id">需要获取的微博ID。</param>
		/// <returns></returns>
		public string Show(string id)
		{
			return (Client.GetCommand("statuses/show",
					new WeiboStringParameter("id", id)));
		}
		/// <summary>
		/// 通过微博（评论、私信）ID获取其MID 
		/// </summary>
		/// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。 </param>
		/// <param name="ids">需要查询的微博（评论、私信）ID</param>
		/// <returns></returns>
		public string QueryMID(int type=1, params string[] ids)
		{
			return (Client.GetCommand("statuses/querymid",
				new WeiboStringParameter("id", string.Join(",",ids)),
				new WeiboStringParameter("type", type),
				new WeiboStringParameter("is_batch", ids.Length==1? 0 : 1)));
		}
		/// <summary>
		/// 通过微博（评论、私信）MID获取其ID 
		/// </summary>
		/// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
		/// <param name="inbox">仅对私信有效，当MID类型为私信时用此参数，0：发件箱、1：收件箱，默认为0 。 </param>
		/// <param name="isBase62">MID是否是base62编码，0：否、1：是，默认为0。 </param>
		/// <param name="mids">需要查询的微博（评论、私信）MID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
		/// <returns></returns>
		public string QueryID(int type = 1, bool inbox = false, bool isBase62 = false, params string[] mids)
		{
			return (Client.GetCommand("statuses/queryid",
				new WeiboStringParameter("mid", string.Join(",", mids)),
				new WeiboStringParameter("type", type),
				new WeiboStringParameter("is_batch", mids.Length == 1 ? 0 : 1),
				new WeiboStringParameter("inbox", inbox),
				new WeiboStringParameter("isBase62", isBase62)));
		}
		/// <summary>
		/// 按天返回热门转发榜 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="baseApp"></param>
		/// <returns></returns>
		public string HotRepostDaily(int count = 20, bool baseApp = false)
		{
			return (Client.GetCommand("statuses/hot/repost_daily",
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("base_app", baseApp)));
		}
		/// <summary>
		/// 按周返回热门转发榜 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="baseApp"></param>
		/// <returns></returns>
		public string HotRepostWeekly(int count = 20, bool baseApp = false)
		{
			return (Client.GetCommand("statuses/hot/repost_weekly",
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("base_app", baseApp)));
		}
		/// <summary>
		/// 按天返回热门评论榜 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="baseApp"></param>
		/// <returns></returns>
		public string HotCommentsDaily(int count = 20, bool baseApp = false)
		{
			return (Client.GetCommand("statuses/hot/comments_daily",
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("base_app", baseApp)));
		}
		/// <summary>
		/// 按周返回热门评论榜 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="baseApp"></param>
		/// <returns></returns>
		public string HotCommentsWeekly(int count = 20, bool baseApp = false)
		{
			return (Client.GetCommand("statuses/hot/comments_weekly",
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("base_app", baseApp)));
		}
		/// <summary>
		/// 批量获取指定微博的转发数评论数 
		/// </summary>
		/// <param name="ids">需要获取数据的微博ID</param>
		/// <returns></returns>
		public string Count(params string[] ids)
		{
			return (Client.GetCommand("statuses/count",
				new WeiboStringParameter("ids", string.Join(",", ids))));
		}
		/// <summary>
		/// 转发一条微博 
		/// </summary>
		/// <param name="id">要转发的微博ID。 </param>
		/// <param name="status">添加的转发文本，内容不超过140个汉字，不填则默认为“转发微博”。 </param>
		/// <param name="isComment">是否在转发的同时发表评论，0：否、1：评论给当前微博、2：评论给原微博、3：都评论，默认为0 。 </param>
		/// <returns></returns>
		public string Repost(string id, string status, int isComment)
		{
			return (Client.PostCommand("statuses/repost",
					new WeiboStringParameter("id", id),
					new WeiboStringParameter("status", status),
					new WeiboStringParameter("is_comment", isComment)));
		}
		/// <summary>
		/// 根据微博ID删除指定微博
		/// </summary>
		/// <param name="id">需要删除的微博ID。 </param>
		/// <returns></returns>
		public string Destroy(string id)
		{
			return (Client.PostCommand("statuses/destroy",
					new WeiboStringParameter("id", id)));
		}
		/// <summary>
		/// 发布一条新微博 
		/// </summary>
		/// <param name="status">要发布的微博文本内容，必须做URLencode，内容不超过140个汉字。</param>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。 </param>
		/// <param name="annotations">元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，必须以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。 </param>
		/// <returns></returns>
		public string Update(string status, float lat = 0.0f, float log = 0.0f, string annotations = "")
		{
			return (Client.PostCommand("statuses/update",
					new WeiboStringParameter("status", status),
					new WeiboStringParameter("lat", lat),
					new WeiboStringParameter("string", log),
					new WeiboStringParameter("annotations", annotations)));
		}
		/// <summary>
		/// 上传图片并发布一条新微博
		/// </summary>
		/// <param name="status">要发布的微博文本内容，内容不超过140个汉字。 </param>
		/// <param name="pic">要上传的图片，仅支持JPEG、GIF、PNG格式，图片大小小于5M。</param>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。 </param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。 </param>
		/// <param name="annotations">元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，必须以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。 </param>
		/// <returns></returns>
		public string Upload(string status, byte[] pic, float lat = 0.0f, float log = 0.0f, string annotations = "")
		{
			return (Client.PostCommand("statuses/upload",true,
						new WeiboStringParameter("status", status),
						new WeiboBinaryParameter("pic",pic),
						new WeiboStringParameter("lat", lat),
						new WeiboStringParameter("string", log),
						new WeiboStringParameter("annotations", annotations)));
		}
		/// <summary>
		/// 指定一个图片URL地址抓取后上传并同时发布一条新微博
		/// </summary>
		/// <param name="status">要发布的微博文本内容，内容不超过140个汉字。 </param>
		/// <param name="url">图片的URL地址，必须以http开头。</param>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。 </param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。 </param>
		/// <param name="annotations">元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，必须以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。 </param>
		/// <returns></returns>
		public string UploadUrlText(string status, string url, float lat = 0.0f, float log = 0.0f, string annotations = "")
		{
			return (Client.PostCommand("statuses/upload_url_text",
						new WeiboStringParameter("status", status),
						new WeiboStringParameter("url", url),
						new WeiboStringParameter("lat", lat),
						new WeiboStringParameter("string", log),
						new WeiboStringParameter("annotations", annotations)));
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="type">表情类别，face：普通表情、ani：魔法表情、cartoon：动漫表情，默认为face。 </param>
		/// <param name="language">语言类别，cnname：简体、twname：繁体，默认为cnname。 </param>
		/// <returns></returns>
		public string Emotions(EmotionType type, LanguageType language)
		{
			return (Client.GetCommand("emotions",
						new WeiboStringParameter("type", type),
						new WeiboStringParameter("language", language)));
		}

	}
}
