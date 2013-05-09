using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	/// <summary>
	/// 位置服务API接口
	/// </summary>
	internal class PlaceAPI : WeiboAPI
	{
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="client"></param>
		public PlaceAPI(Client client)
			: base(client)
		{

		}

		public string PublicTimeline(int count = 20, bool baseApp=false)
		{
			return Client.GetCommand("place/public_timeline",
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("base_app", baseApp));
		}

		public string FriendsTimeline(string sinceID="0",string maxID="0", int count = 20, int page=1, int type=0)
		{
			return Client.GetCommand("place/friends_timeline",
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("type", type));
		}

		public string UserTimeline(string uid, string sinceID = "0", string maxID = "0", int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/user_timeline",
				new WeiboStringParameter("uid", uid),
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp));
		}

		public string POITimeline(string poiID, string sinceID = "0", string maxID = "0", int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/poi_timeline",
				new WeiboStringParameter("poiid", poiID),
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp));
		}

		public string NearByTimeline(float lat, float log, int range = 2000, int startTime = 0, int endTime = 0, bool sort = false, int count = 20, int page = 1, bool baseApp = false, bool offset = false)
		{
			return Client.GetCommand("place/nearby_timeline",
				new WeiboStringParameter("lat ", lat),
				new WeiboStringParameter("long", log),
				new WeiboStringParameter("starttime", startTime),
				new WeiboStringParameter("endtime", endTime),
				new WeiboStringParameter("sort", sort),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp),
				new WeiboStringParameter("offset", offset));
		}

		public string StatusesShow(string id)
		{
			return Client.GetCommand("place/statuses/show",
				new WeiboStringParameter("id", id));
		}

		public string UsersShow(string uid, bool baseApp = false)
		{
			return Client.GetCommand("place/users/show",
					new WeiboStringParameter("uid", uid),
					new WeiboStringParameter("baseApp", false));
		}

		public string UserCheckins(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/users/checkins",
					new WeiboStringParameter("uid", uid),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("base_app", baseApp),
					new WeiboStringParameter("baseApp", false));
		}

		public string UserPhotos(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/users/photos",
					new WeiboStringParameter("uid", uid),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("base_app", baseApp),
					new WeiboStringParameter("baseApp", false));
		}

		public string UserTips(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/users/tips",
					new WeiboStringParameter("uid", uid),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("base_app", baseApp),
					new WeiboStringParameter("baseApp", false));
		}

		public string UserTodos(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/users/todos",
						new WeiboStringParameter("uid", uid),
						new WeiboStringParameter("count", count),
						new WeiboStringParameter("page", page),
						new WeiboStringParameter("base_app", baseApp),
						new WeiboStringParameter("baseApp", false));
		}

		public string POIShow(string poiID, bool baseApp = false)
		{
			return Client.GetCommand("place/pois/show",
				new WeiboStringParameter("poiID", poiID),
				new WeiboStringParameter("base_app", baseApp));
		}

		public string POIUsers(string poiID, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/pois/users",
				new WeiboStringParameter("poiID", poiID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("base_app", baseApp));
		}

		public string POITips(string poiID, int count = 20, int page = 1, bool sort = false, bool baseApp = false)
		{
			return Client.GetCommand("place/pois/tipss",
				new WeiboStringParameter("poiID", poiID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("sort", sort),
				new WeiboStringParameter("base_app", baseApp));
		}

		public string POIPhotos(string poiID, int count = 20, int page = 1, bool sort = false, bool baseApp = false)
		{
			return Client.GetCommand("place/pois/photos",
				new WeiboStringParameter("poiID", poiID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("sort", sort),
				new WeiboStringParameter("base_app", baseApp));
		}

		public string POISearch(string keyword, string city, string category, int count = 20, int page = 1)
		{
			return Client.GetCommand("place/pois/search",
				new WeiboStringParameter("keyword", keyword),
				new WeiboStringParameter("city", city),
				new WeiboStringParameter("category", category),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page));
		}

		public string POICategory(string pid = "", bool flag = false)
		{
			return Client.GetCommand("place/pois/category",
				new WeiboStringParameter("pid", pid),
				new WeiboStringParameter("flag", flag));
		}

		public string NearByPOIs(float lat, float log, int range = 2000, string q = "", string category = "", int count = 20, int page = 1, bool sort = false, bool offset = false)
		{
			return Client.GetCommand("place/nearby/pois",
				new WeiboStringParameter("lat", lat),
				new WeiboStringParameter("long", log),
				new WeiboStringParameter("range", range),
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("category", category),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("sort", sort),
				new WeiboStringParameter("offset", offset));
		}

		public string NearByUsers(float lat, float log, int range = 2000, int count = 20, int page = 1, int startTime = 0, int endTime = 0, bool sort = false, bool offset = false)
		{
			return Client.GetCommand("place/nearby/users",
				new WeiboStringParameter("lat", lat),
				new WeiboStringParameter("long", log),
				new WeiboStringParameter("range", range),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("starttime", startTime),
				new WeiboStringParameter("endtime", endTime),
				new WeiboStringParameter("sort", sort),
				new WeiboStringParameter("offset", offset));
		}

		public string NearByPhotos(float lat, float log, int range = 2000, int count = 20, int page = 1, int startTime = 0, int endTime = 0, bool sort = false, bool offset = false)
		{
			return Client.GetCommand("place/nearby/photos",
				new WeiboStringParameter("lat", lat),
				new WeiboStringParameter("long", log),
				new WeiboStringParameter("range", range),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("starttime", startTime),
				new WeiboStringParameter("endtime", endTime),
				new WeiboStringParameter("sort", sort),
				new WeiboStringParameter("offset", offset));
		}

		public string NearByUserList(float lat, float log, int count = 20, int page = 1, int range = 2000, bool sort = false, int filter=0,int gender = 0, int level=0, int startAge=0,int endAge =0, bool offset = false)
		{
			return Client.GetCommand("place/nearby/users",
				new WeiboStringParameter("lat", lat),
				new WeiboStringParameter("long", log),
				new WeiboStringParameter("range", range),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("filter", filter),
				new WeiboStringParameter("gender", gender),
				new WeiboStringParameter("level", level),
				new WeiboStringParameter("startbirth", startAge),
				new WeiboStringParameter("endbirth", endAge),
				new WeiboStringParameter("sort", sort),
				new WeiboStringParameter("offset", offset));
		}

		public string CreatePOI(string title, string address, string category = "500", float lat = 0.0f, float log = 0.0f, string city = "", string province = "", string country = "", string phone = "", string postcode = "", string extra = "")
		{
			return Client.PostCommand("place/pois/create",
				new WeiboStringParameter("title", title),
				new WeiboStringParameter("address", address),
				new WeiboStringParameter("category", category),
				new WeiboStringParameter("lat", lat),
				new WeiboStringParameter("long", log),
				new WeiboStringParameter("city", city),
				new WeiboStringParameter("province", province),
				new WeiboStringParameter("country", country),
				new WeiboStringParameter("phone", phone),
				new WeiboStringParameter("postcode", postcode),
				new WeiboStringParameter("extra", extra));
		}

		public string CheckIn(string poiID, string status, byte[] pic, bool isPublic = true)
		{
			return Client.PostCommand("place/pois/create",true,
				new WeiboStringParameter("poiid", poiID),
				new WeiboStringParameter("status", status),
				new WeiboBinaryParameter("pic", pic),
				new WeiboStringParameter("public", isPublic));
		}

		public string AddPhoto(string poiID, string status, byte[] pic, bool isPublic = true)
		{
			return Client.PostCommand("place/pois/add_photo", true,
				new WeiboStringParameter("poiid", poiID),
				new WeiboStringParameter("status", status),
				new WeiboBinaryParameter("pic", pic),
				new WeiboStringParameter("public", isPublic));
		}

		public string AddTip(string poiID, string status, bool isPublic = true)
		{
			return Client.PostCommand("place/pois/add_tip", 
				new WeiboStringParameter("poiid", poiID),
				new WeiboStringParameter("status", status),
				new WeiboStringParameter("public", isPublic));
		}

		public string AddTodo(string poiID, string status, bool isPublic = true)
		{
			return Client.PostCommand("place/pois/add_todo",
				new WeiboStringParameter("poiid", poiID),
				new WeiboStringParameter("status", status),
				new WeiboStringParameter("public", isPublic));
		}

		public string CreateUserPosition(float lat, float log)
		{
			return Client.PostCommand("place/pois/add_todo",
				  new WeiboStringParameter("lat", lat),
				  new WeiboStringParameter("long", log));
		}

		public string DestoryUserPostion()
		{
			return Client.PostCommand("place/pois/add_todo");
		}



	}
}
