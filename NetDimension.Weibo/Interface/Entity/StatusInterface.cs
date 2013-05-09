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
	/// Status接口
	/// </summary>
	public class StatusInterface : WeiboInterface
	{
		StatusAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public StatusInterface(Client client)
			: base(client)
		{
			api = new StatusAPI(client);
		}

		/// <summary>
		/// 返回最新的公共微博 
		/// </summary>
		/// <see cref=string.Empty/>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns>dynamic json</returns>
		public Entities.status.Collection PublicTimeline(int count = 50, int page = 1, bool baseApp = false)
		{
			return JsonConvert.DeserializeObject<Entities.status.Collection>(api.PublicTimeline(count, page, baseApp));
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
		public Entities.status.Collection FriendsTimeline(string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return JsonConvert.DeserializeObject<Entities.status.Collection>(api.FriendsTimeline(sinceID, maxID, count, page, baseApp, feature));
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
		public Entities.status.Collection HomeTimeline(string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return JsonConvert.DeserializeObject<Entities.status.Collection>(api.HomeTimeline(sinceID, maxID, count, page, baseApp, feature));
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
		public Entities.status.IDs FriendsTimelineIDs(string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return JsonConvert.DeserializeObject<Entities.status.IDs>(api.FriendsTimeline(sinceID, maxID, count, page, baseApp, feature));
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
		public Entities.status.Collection UserTimeline(string uid = "", string screenName = "", string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0, bool trimUser = false)
		{
			return JsonConvert.DeserializeObject<Entities.status.Collection>(api.UserTimeline(uid, screenName, sinceID, maxID, count, page, baseApp, feature, trimUser));
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
		public Entities.status.IDs UserTimelineIDs(string uid = "", string screenName = "", string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return JsonConvert.DeserializeObject<Entities.status.IDs>(api.UserTimelineIDs(uid, screenName, sinceID, maxID, count, page, baseApp, feature));
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
		public Entities.repost.Collection RepostTimeline(string id, string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0)
		{
			return JsonConvert.DeserializeObject<Entities.repost.Collection>(api.RepostTimeline(id, sinceID, maxID, count, page, filterByAuthor));
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
		public Entities.status.IDs RepostTimelineIDs(string id, string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0)
		{
			return JsonConvert.DeserializeObject<Entities.status.IDs>(api.RepostTimelineIDs(id, sinceID, maxID, count, page, filterByAuthor));
		}
		/// <summary>
		/// 获取当前用户最新转发的微博列表 
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。 </param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public Entities.status.Collection RepostByMe(string sinceID = "", string maxID = "", int count = 50, int page = 1)
		{
			return JsonConvert.DeserializeObject<Entities.status.Collection>(api.RepostByMe(sinceID, maxID, count, page));
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
		public Entities.status.Collection Mentions(string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0, int filterBySource = 0, int filterByType = 0)
		{
			return JsonConvert.DeserializeObject<Entities.status.Collection>(api.Mentions(sinceID, maxID, count, page, filterByAuthor, filterBySource, filterByType));
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
		public Entities.status.IDs MentionIDs(string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0, int filterBySource = 0, int filterByType = 0)
		{
			return JsonConvert.DeserializeObject<Entities.status.IDs>(api.MentionIDs(sinceID, maxID, count, page, filterByAuthor, filterBySource, filterByType));
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
		public Entities.status.Collection BilateralTimeline(string sinceID = "", string maxID = "", int count = 50, int page = 1, bool baseApp = false, int feature = 0)
		{
			return JsonConvert.DeserializeObject<Entities.status.Collection>(api.BilateralTimeline(sinceID, maxID, count, page, baseApp, feature));
		}
		/// <summary>
		/// 根据微博ID获取单条微博内容 
		/// </summary>
		/// <param name="id">需要获取的微博ID。</param>
		/// <returns></returns>
		public Entities.status.Entity Show(string id)
		{
			return JsonConvert.DeserializeObject<Entities.status.Entity>(api.Show(id));
		}
		/// <summary>
		/// 通过微博（评论、私信）ID获取其MID 
		/// </summary>
		/// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。 </param>
		/// <param name="ids">需要查询的微博（评论、私信）ID</param>
		/// <returns></returns>
		public string QueryMID(int type = 1, string id="")
		{
			return string.Format("{0}", JObject.Parse(api.QueryMID(type, id))["mid"]);
		}
		/// <summary>
		/// 通过微博（评论、私信）ID获取其MID 
		/// </summary>
		/// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。 </param>
		/// <param name="ids">需要查询的微博（评论、私信）ID</param>
		/// <returns></returns>
		public IEnumerable<string> QueryMID(int type=1, params string[] ids)
		{
			return Utility.GetStringListFromJSON(api.QueryMID(type, ids));
		}

		/// <summary>
		/// 通过微博（评论、私信）MID获取其ID 
		/// </summary>
		/// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
		/// <param name="inbox">仅对私信有效，当MID类型为私信时用此参数，0：发件箱、1：收件箱，默认为0 。 </param>
		/// <param name="isBase62">MID是否是base62编码，0：否、1：是，默认为0。 </param>
		/// <param name="mids">需要查询的微博（评论、私信）MID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
		/// <returns></returns>
		public string QueryID(int type = 1, bool inbox = false, bool isBase62 = false, string mids="")
		{
			return string.Format("{0}", JObject.Parse(api.QueryID(type, inbox, isBase62, mids))["id"]);
		}

		/// <summary>
		/// 通过微博（评论、私信）MID获取其ID 
		/// </summary>
		/// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
		/// <param name="inbox">仅对私信有效，当MID类型为私信时用此参数，0：发件箱、1：收件箱，默认为0 。 </param>
		/// <param name="isBase62">MID是否是base62编码，0：否、1：是，默认为0。 </param>
		/// <param name="mids">需要查询的微博（评论、私信）MID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
		/// <returns></returns>
		public IEnumerable<string> QueryID(int type = 1, bool inbox = false, bool isBase62 = false, params string[] mids)
		{
			return Utility.GetStringListFromJSON(api.QueryID(type, inbox, isBase62, mids));
		}
		/// <summary>
		/// 按天返回热门转发榜 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="baseApp"></param>
		/// <returns></returns>
		public IEnumerable<Entities.status.Entity> HotRepostDaily(int count = 20, bool baseApp = false)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.status.Entity>>(api.HotRepostDaily(count, baseApp));
		}
		/// <summary>
		/// 按周返回热门转发榜 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="baseApp"></param>
		/// <returns></returns>
		public IEnumerable<Entities.status.Entity> HotRepostWeekly(int count = 20, bool baseApp = false)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.status.Entity>>(api.HotRepostWeekly(count, baseApp));
		}
		/// <summary>
		/// 按天返回热门评论榜 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="baseApp"></param>
		/// <returns></returns>
		public IEnumerable<Entities.status.Entity> HotCommentsDaily(int count = 20, bool baseApp = false)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.status.Entity>>(api.HotCommentsDaily(count, baseApp));
		}
		/// <summary>
		/// 按周返回热门评论榜 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="baseApp"></param>
		/// <returns></returns>
		public IEnumerable<Entities.status.Entity> HotCommentsWeekly(int count = 20, bool baseApp = false)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.status.Entity>>(api.HotCommentsWeekly(count, baseApp));
		}
		/// <summary>
		/// 批量获取指定微博的转发数评论数 
		/// </summary>
		/// <param name="ids">需要获取数据的微博ID</param>
		/// <returns></returns>
		public Entities.status.Count Count(params string[] ids)
		{
			return JsonConvert.DeserializeObject<Entities.status.Count>(api.Count(ids));
		}
		/// <summary>
		/// 转发一条微博 
		/// </summary>
		/// <param name="id">要转发的微博ID。 </param>
		/// <param name="status">添加的转发文本，内容不超过140个汉字，不填则默认为“转发微博”。 </param>
		/// <param name="isComment">是否在转发的同时发表评论，0：否、1：评论给当前微博、2：评论给原微博、3：都评论，默认为0 。 </param>
		/// <returns></returns>
		public Entities.status.Entity Repost(string id, string status, int isComment)
		{
			return JsonConvert.DeserializeObject<Entities.status.Entity>(api.Repost(id, status, isComment));
		}
		/// <summary>
		/// 根据微博ID删除指定微博
		/// </summary>
		/// <param name="id">需要删除的微博ID。 </param>
		/// <returns></returns>
		public Entities.status.Entity Destroy(string id)
		{
			return JsonConvert.DeserializeObject<Entities.status.Entity>(api.Destroy(id));
		}
		/// <summary>
		/// 发布一条新微博 
		/// </summary>
		/// <param name="status">要发布的微博文本内容，必须做URLencode，内容不超过140个汉字。</param>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。 </param>
		/// <param name="annotations">元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，必须以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。 </param>
		/// <returns></returns>
		public Entities.status.Entity Update(string status, float lat = 0.0f, float log = 0.0f, string annotations = "")
		{
			return JsonConvert.DeserializeObject<Entities.status.Entity>(api.Update(status, lat, log, annotations));
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
		public Entities.status.Entity Upload(string status, byte[] pic, float lat = 0.0f, float log = 0.0f, string annotations = "")
		{
			return JsonConvert.DeserializeObject<Entities.status.Entity>(api.Upload(status, pic, lat, log, annotations));
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
		public Entities.status.Entity UploadUrlText(string status, string url, float lat = 0.0f, float log = 0.0f, string annotations = "")
		{
			return JsonConvert.DeserializeObject<Entities.status.Entity>(api.UploadUrlText(status, url, lat, log, annotations));
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="type">表情类别，face：普通表情、ani：魔法表情、cartoon：动漫表情，默认为face。 </param>
		/// <param name="language">语言类别，cnname：简体、twname：繁体，默认为cnname。 </param>
		/// <returns></returns>
		public IEnumerable<Entities.status.Emotion> Emotions(EmotionType type= EmotionType.face, LanguageType language= LanguageType.cnname)
		{
			return JsonConvert.DeserializeObject<IEnumerable<Entities.status.Emotion>>(api.Emotions(type, language));
		}

	}
}
