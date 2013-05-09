using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codeplex.Data;

namespace NetDimension.Weibo.Interface.Dynamic
{
	/// <summary>
	/// Place接口
	/// </summary>
	public class PlaceInterface : WeiboInterface
	{
		PlaceAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public PlaceInterface(Client client)
			: base(client)
		{
			api = new PlaceAPI(client);
		}
		/// <summary>
		/// 获取最新20条公共的位置动态  
		/// </summary>
		/// <param name="count">返回的动态数，最大为50，默认为20。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns></returns>
		public dynamic PublicTimeline(int count = 20, bool baseApp = false)
		{
			return DynamicJson.Parse(api.PublicTimeline(count,baseApp));
		}
		/// <summary>
		/// 获取当前登录用户与其好友的位置动态  
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。 </param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="type">关系过滤，0：仅返回关注的，1：返回好友的，默认为0</param>
		/// <returns></returns>
		public dynamic FriendsTimeline(string sinceID = "0", string maxID = "0", int count = 20, int page = 1, int type = 0) {
			return DynamicJson.Parse(api.FriendsTimeline(sinceID,maxID,count,page,type));
		}
		/// <summary>
		/// 获取某个用户的位置动态 
		/// </summary>
		/// <param name="uid">需要查询的用户ID。 </param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。 </param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，最大为50，默认为20。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns></returns>
		public dynamic UserTimeline(string uid, string sinceID = "0", string maxID = "0", int count = 20, int page = 1, bool baseApp = false)
		{
			return DynamicJson.Parse(api.UserTimeline(uid,sinceID,maxID,count,page,baseApp));
		}
		/// <summary>
		/// 获取某个位置地点的动态 
		/// </summary>
		/// <param name="poiID">需要查询的POI点ID</param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的微博，默认为0</param>
		/// <param name="count">单页返回的记录条数，最大为50，默认为20</param>
		/// <param name="page">返回结果的页码，默认为1</param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0</param>
		/// <returns></returns>
		public dynamic POITimeline(string poiID, string sinceID = "0", string maxID = "0", int count = 20, int page = 1, bool baseApp = false)
		{
			return DynamicJson.Parse(api.POITimeline(poiID,sinceID,maxID,count,page,baseApp));
		}
		/// <summary>
		/// 获取某个位置周边的动态
		/// </summary>
		/// <param name="lat">纬度。有效范围：-90.0到+90.0，+表示北纬。 </param>
		/// <param name="log">经度。有效范围：-180.0到+180.0，+表示东经。</param>
		/// <param name="range">搜索范围，单位米，默认2000米，最大11132米。 </param>
		/// <param name="startTime">开始时间，Unix时间戳</param>
		/// <param name="endTime">结束时间，Unix时间戳。 </param>
		/// <param name="sort">排序方式。默认为0，按时间排序；为1时按与中心点距离进行排序。 </param>
		/// <param name="count">单页返回的记录条数，最大为50，默认为20。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <param name="offset">传入的经纬度是否是纠偏过，0：没纠偏、1：纠偏过，默认为0。 </param>
		/// <returns></returns>
		public dynamic NearByTimeline(float lat, float log, int range = 2000, int startTime = 0, int endTime = 0, bool sort = false, int count = 20, int page = 1, bool baseApp = false, bool offset = false)
		{
			return DynamicJson.Parse(api.NearByTimeline(lat,log,range,startTime,endTime,sort,count,page,baseApp,offset));
		}
		/// <summary>
		/// 根据ID获取动态的详情
		/// </summary>
		/// <param name="id">需要获取的动态ID。</param>
		/// <returns></returns>
		public dynamic StatusesShow(string id)
		{
			return DynamicJson.Parse(api.StatusesShow(id));
		}
		/// <summary>
		/// 获取LBS位置服务内的用户信息
		/// </summary>
		/// <param name="uid">需要查询的用户ID。</param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
		/// <returns></returns>
		public dynamic UsersShow(string uid, bool baseApp = false) {
			return DynamicJson.Parse(api.UsersShow(uid,baseApp));
		}
		/// <summary>
		/// 获取用户签到过的地点列表 
		/// </summary>
		/// <param name="uid">需要查询的用户ID</param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns></returns>
		public dynamic UserCheckins(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return DynamicJson.Parse(api.UserCheckins(uid,count,page,baseApp));
		}
		/// <summary>
		/// 获取用户的照片列表 
		/// </summary>
		/// <param name="uid">需要查询的用户ID。</param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
		/// <returns></returns>
		public dynamic UserPhotos(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return DynamicJson.Parse(api.UserPhotos(uid,count,page,baseApp));
		}
		/// <summary>
		/// 获取用户的点评列表 
		/// </summary>
		/// <param name="uid">需要查询的用户ID</param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns></returns>
		public dynamic UserTips(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return DynamicJson.Parse(api.UserTips(uid,count,page,baseApp));
		}
		/// <summary>
		/// 获取用户的todo列表 
		/// </summary>
		/// <param name="uid">需要查询的用户ID。 </param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns></returns>
		public dynamic UserTodos(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return DynamicJson.Parse(api.UserTodos(uid,count,page,baseApp));
		}
		/// <summary>
		/// 获取地点详情 
		/// </summary>
		/// <param name="poiID">需要查询的POI地点ID。</param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns></returns>
		public dynamic POIShow(string poiID, bool baseApp = false)
		{
			return DynamicJson.Parse(api.POIShow(poiID,baseApp));
		}
		/// <summary>
		/// 获取在某个地点签到的人的列表
		/// </summary>
		/// <param name="poiID">需要查询的POI地点ID。 </param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns></returns>
		public dynamic POIUsers(string poiID, int count = 20, int page = 1, bool baseApp = false)
		{
			return DynamicJson.Parse(api.POIUsers(poiID,count,page,baseApp));
		}
		/// <summary>
		/// 获取地点点评列表
		/// </summary>
		/// <param name="poiID">需要查询的POI地点ID。</param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="sort">排序方式，0：按时间、1：按热门，默认为0，目前只支持0。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。 </param>
		/// <returns></returns>
		public dynamic POITips(string poiID, int count = 20, int page = 1, bool sort = false, bool baseApp = false)
		{
			return DynamicJson.Parse(api.POITips(poiID,count,page,sort,baseApp));
		}
		/// <summary>
		/// 获取地点照片列表 
		/// </summary>
		/// <param name="poiID">需要查询的POI地点ID。</param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="sort">排序方式，0：按时间、1：按热门，默认为0，目前只支持0。 </param>
		/// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
		/// <returns></returns>
		public dynamic POIPhotos(string poiID, int count = 20, int page = 1, bool sort = false, bool baseApp = false)
		{
			return DynamicJson.Parse(api.POIPhotos(poiID,count,page,sort,baseApp));
		}
		/// <summary>
		/// 按省市查询地点 
		/// </summary>
		/// <param name="keyword">查询的关键词</param>
		/// <param name="city">城市代码，默认为全国搜索</param>
		/// <param name="category">查询的分类代码，取值范围见：分类代码对应表。</param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public dynamic POISearch(string keyword, string city, string category, int count = 20, int page = 1)
		{
			return DynamicJson.Parse(api.POISearch(keyword,city,category,count,page));
		}
		/// <summary>
		/// 获取地点分类 
		/// </summary>
		/// <param name="pid">父分类ID，默认为0。</param>
		/// <param name="flag">是否返回全部分类，0：只返回本级下的分类，1：返回全部分类，默认为0。</param>
		/// <returns></returns>
		public dynamic POICategory(string pid = "", bool flag = false)
		{
			return DynamicJson.Parse(api.POICategory(pid,flag));
		}
		/// <summary>
		/// 获取附近地点 
		/// </summary>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬</param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经。 </param>
		/// <param name="range">查询范围半径，默认为2000，最大为10000，单位米。 </param>
		/// <param name="q">查询的关键词</param>
		/// <param name="category">查询的分类代码，取值范围见：分类代码对应表。 </param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="sort">排序方式，0：按权重，默认为0。 </param>
		/// <param name="offset">传入的经纬度是否是纠偏过，0：没纠偏、1：纠偏过，默认为0。 </param>
		/// <returns></returns>
		public dynamic NearByPOIs(float lat, float log, int range = 2000, string q = "", string category = "", int count = 20, int page = 1, bool sort = false, bool offset = false)
		{
			return DynamicJson.Parse(api.NearByPOIs(lat,log,range,q,category,count,page,sort,offset));
		}
		/// <summary>
		/// 获取附近发位置微博的人 
		/// </summary>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬。 </param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经。 </param>
		/// <param name="range">查询范围半径，默认为2000，最大为11132，单位米。 </param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="startTime">开始时间，Unix时间戳。 </param>
		/// <param name="endTime">结束时间，Unix时间戳。 </param>
		/// <param name="sort">排序方式，0：按时间、1：按距离，默认为0。 </param>
		/// <param name="offset">传入的经纬度是否是纠偏过，0：没纠偏、1：纠偏过，默认为0。</param>
		/// <returns></returns>
		public dynamic NearByUsers(float lat, float log, int range = 2000, int count = 20, int page = 1, int startTime = 0, int endTime = 0, bool sort = false, bool offset = false)
		{
			return DynamicJson.Parse(api.NearByUsers(lat,log,range,count,page,startTime,endTime,sort,offset));
		}
		/// <summary>
		/// 获取附近照片 
		/// </summary>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬。 </param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经。 </param>
		/// <param name="range">查询范围半径，默认为500，最大为11132，单位米。 </param>
		/// <param name="count">单页返回的记录条数，默认为20，最大为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="startTime">开始时间，Unix时间戳。 </param>
		/// <param name="endTime">结束时间，Unix时间戳。 </param>
		/// <param name="sort">排序方式，0：按时间、1：按距离，默认为0。 </param>
		/// <param name="offset">传入的经纬度是否是纠偏过，0：没纠偏、1：纠偏过，默认为0。 </param>
		/// <returns></returns>
		public dynamic NearByPhotos(float lat, float log, int range = 2000, int count = 20, int page = 1, int startTime = 0, int endTime = 0, bool sort = false, bool offset = false)
		{
			return DynamicJson.Parse(api.NearByPhotos(lat,log,range,count,page,startTime,endTime,sort,offset));
		}
		/// <summary>
		/// 获取附近的人 
		/// </summary>
		/// <param name="lat">动态发生的纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
		/// <param name="log">动态发生的经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。 </param>
		/// <param name="count">单页返回的记录条数，最大为50，默认为20。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="range">查询范围半径，默认为2000，最大为11132。</param>
		/// <param name="sort">排序方式，0：按时间、1：按距离、2：按社会化关系，默认为2。</param>
		/// <param name="filter">用户关系过滤，0：全部、1：只返回陌生人、2：只返回关注人，默认为0。 </param>
		/// <param name="gender">性别过滤，0：全部、1：男、2：女，默认为0。</param>
		/// <param name="level">用户级别过滤，0：全部、1：普通用户、2：VIP用户、7：达人，默认为0。 </param>
		/// <param name="startAge">与参数endbirth一起定义过滤年龄段，数值为年龄大小，默认为空。 </param>
		/// <param name="endAge">与参数startbirth一起定义过滤年龄段，数值为年龄大小，默认为空。 </param>
		/// <param name="offset">传入的经纬度是否是纠偏过，0：没纠偏、1：纠偏过，默认为0。 </param>
		/// <returns></returns>
		public dynamic NearByUserList(float lat, float log, int count = 20, int page = 1, int range = 2000, bool sort = false, int filter = 0, int gender = 0, int level = 0, int startAge = 0, int endAge = 0, bool offset = false)
		{
			return DynamicJson.Parse(api.NearByUserList(lat,log,count,page,range,sort,filter,gender,level,startAge,endAge,offset));
		}
		/// <summary>
		/// 添加地点
		/// </summary>
		/// <param name="title">POI点的名称，不超过30个字符</param>
		/// <param name="address">POI点的地址，不超过60个字符</param>
		/// <param name="category">POI的类型分类代码，取值范围见：分类代码对应表，默认为500。</param>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬。 </param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经。 </param>
		/// <param name="city">城市代码。 </param>
		/// <param name="province">省份代码</param>
		/// <param name="country">国家代码</param>
		/// <param name="phone">POI点的电话，不超过14个字符</param>
		/// <param name="postcode">POI点的邮编</param>
		/// <param name="extra">其他</param>
		/// <returns></returns>
		public dynamic CreatePOI(string title, string address, string category = "500", float lat = 0.0f, float log = 0.0f, string city = "", string province = "", string country = "", string phone = "", string postcode = "", string extra = "")
		{
			return DynamicJson.Parse(api.CreatePOI(title,address,category,lat,log,city,province,country,phone,postcode,extra));
		}
		/// <summary>
		/// 签到同时可以上传一张图片 
		/// </summary>
		/// <param name="poiID">需要签到的POI地点ID。</param>
		/// <param name="status">签到时发布的动态内容，内容不超过140个汉字</param>
		/// <param name="pic">需要上传的图片，仅支持JPEG、GIF、PNG格式，图片大小小于5M。</param>
		/// <param name="isPublic">是否同步到微博，1：是、0：否，默认为0。</param>
		/// <returns></returns>
		public dynamic CheckIn(string poiID, string status, byte[] pic, bool isPublic = true)
		{
			return DynamicJson.Parse(api.CheckIn(poiID,status,pic,isPublic));
		}
		/// <summary>
		/// 添加照片 
		/// </summary>
		/// <param name="poiID">需要添加照片的POI地点ID。 </param>
		/// <param name="status">签到时发布的动态内容，，内容不超过140个汉字</param>
		/// <param name="pic">需要上传的图片，仅支持JPEG、GIF、PNG格式，图片大小小于5M。 </param>
		/// <param name="isPublic">是否同步到微博，1：是、0：否，默认为0。 </param>
		/// <returns></returns>
		public dynamic AddPhoto(string poiID, string status, byte[] pic, bool isPublic = true)
		{
			return DynamicJson.Parse(api.AddPhoto(poiID,status,pic,isPublic));
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="poiID">添加点评</param>
		/// <param name="status">点评时发布的动态内容，内容不超过140个汉字。 </param>
		/// <param name="isPublic">是否同步到微博，1：是、0：否，默认为0。 </param>
		/// <returns></returns>
		public dynamic AddTip(string poiID, string status, bool isPublic = true)
		{
			return DynamicJson.Parse(api.AddTip(poiID,status,isPublic));
		}
		/// <summary>
		/// 添加todo 
		/// </summary>
		/// <param name="poiID">需要添加todo的POI地点ID。</param>
		/// <param name="status">添加todo时发布的动态内容，内容不超过140个汉字。</param>
		/// <param name="isPublic">是否同步到微博，1：是、0：否，默认为0。 </param>
		/// <returns></returns>
		public dynamic AddTodo(string poiID, string status, bool isPublic = true)
		{
			return DynamicJson.Parse(api.AddTodo(poiID,status,isPublic));
		}
		/// <summary>
		/// 用户添加自己的位置 
		/// </summary>
		/// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬。 </param>
		/// <param name="log">经度，有效范围：-180.0到+180.0，+表示东经。 </param>
		/// <returns></returns>
		public dynamic CreateUserPosition(float lat, float log)
		{
			return DynamicJson.Parse(api.CreateUserPosition(lat,log));
		}
		/// <summary>
		/// 用户删除自己的位置 
		/// </summary>
		/// <returns></returns>
		public dynamic DestoryUserPostion()
		{
			return DynamicJson.Parse(api.DestoryUserPostion());
		}



	}
}
