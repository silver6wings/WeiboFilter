using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	/// <summary>
	/// 地理信息API接口
	/// </summary>
	internal class LocationAPI:WeiboAPI
	{
		public LocationAPI(Client client)
			: base(client)
		{

		}

		public string GetMapImage(string center="", string city="", string coordinates = "", string names = null, string offsetX = "", string offsetY = "", string font = "", string lines = "", string polygons = "", string size = "240×240", string format = "png", string zoom = "", bool scale = false, bool traffic = false)
		{
			return Client.GetCommand("location/base/get_map_image",
				new WeiboStringParameter("center_coordinate", center),
				new WeiboStringParameter("city", city),
				new WeiboStringParameter("coordinates", coordinates),
				new WeiboStringParameter("names", names),
				new WeiboStringParameter("offset_x", offsetX),
				new WeiboStringParameter("offset_x", offsetY),
				new WeiboStringParameter("font", font),
				new WeiboStringParameter("lines", lines),
				new WeiboStringParameter("polygons", polygons),
				new WeiboStringParameter("size", size),
				new WeiboStringParameter("format", format),
				new WeiboStringParameter("zoom", zoom),
				new WeiboStringParameter("scale", scale.ToString().ToLower()),
				new WeiboStringParameter("traffic", traffic.ToString().ToLower()));
		}

		public string IPtoGeo(string[] ips)
		{
			return Client.GetCommand("location/geo/ip_to_geo", new WeiboStringParameter("ip", string.Join(",",ips)));
		}

		public string AddressToGeo(string address)
		{
			return Client.GetCommand("location/geo/address_to_geo", new WeiboStringParameter("address", address));
		}

		public string GeoToAddress(string coordinate)
		{
			return Client.GetCommand("location/geo/geo_to_address", new WeiboStringParameter("coordinate", coordinate));
		}

		public string GpsToOffset(string coordinate)
		{
			return Client.GetCommand("location/geo/gps_to_offset", new WeiboStringParameter("coordinate", coordinate));
		}

		public string IsDomestic(string coordinates)
		{
			return Client.GetCommand("location/geo/is_domestic", new WeiboStringParameter("coordinate", coordinates));
		}

		public string ShowPOIs(string[] srcids)
		{
			return Client.GetCommand("location/pois/show_batch", new WeiboStringParameter("srcids ", string.Join(",",srcids)));
		}

		public string SearchPOIsByLocation(string q = "", string category = "", string city = "", int page = 1, int count = 20)
		{
			return Client.GetCommand("location/pois/search/by_location",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("category", category),
				new WeiboStringParameter("city", city),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("count", count));
		}

		public string SearchPOIsByGeo(string q = "", string category = "", string coordinate = "",string pid="", string city="",int range=500, int page = 1, int count = 20)
		{
			return Client.GetCommand("location/pois/search/by_geo",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("category", category),
				new WeiboStringParameter("coordinate", coordinate),
				new WeiboStringParameter("pid", pid),
				new WeiboStringParameter("city", city),
				new WeiboStringParameter("range", range),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("count", count));
		}

		public string SearchPOIsByArea(string q = "", string category = "", string coordinates = "", string city = "", int page = 1, int count = 20)
		{
			return Client.GetCommand("location/pois/search/by_geo",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("category", category),
				new WeiboStringParameter("coordinates", coordinates),
				new WeiboStringParameter("city", city),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("count", count));
		}

		public string AddPOI(string srcid, string name, string address, string cityName, string category, string longitude, string latitude, string phone = "", string picUrl = "", string url = "", string tags = "", string description = "", string intro = "", string traffic = "")
		{
			return Client.PostCommand("location/pois/add",
				new WeiboStringParameter("srcid", srcid),
				new WeiboStringParameter("name", name),
				new WeiboStringParameter("address", address),
				new WeiboStringParameter("cityName", cityName),
				new WeiboStringParameter("category", category),
				new WeiboStringParameter("longitude", longitude),
				new WeiboStringParameter("latitude", latitude),
				new WeiboStringParameter("telephone", phone),
				new WeiboStringParameter("pic_url", picUrl),
				new WeiboStringParameter("url", url),
				new WeiboStringParameter("tags", tags),
				new WeiboStringParameter("description", description),
				new WeiboStringParameter("intro", intro),
				new WeiboStringParameter("traffic", traffic));
		}

		public string GetLocationByMobileStation(string json)
		{
			return Client.GetCommand("location/mobile/get_location", new WeiboStringParameter("json", json));
		}

		public string DriveRouteLine(string beginPID = "", string beginCoordinate = "", string endPID = "", string endCoordinate = "", int type = 0)
		{
			return Client.GetCommand("location/line/drive_route",
				string.IsNullOrEmpty(beginPID) ? new WeiboStringParameter("begin_coordinate", beginCoordinate) : new WeiboStringParameter("begin_pid", beginPID),
				string.IsNullOrEmpty(endPID) ? new WeiboStringParameter("end_coordinate", endCoordinate) : new WeiboStringParameter("end_pid", endPID),
				new WeiboStringParameter("type", type));
		}

		public string BusRouteLine(string beginPID = "", string beginCoordinate = "", string endPID = "", string endCoordinate = "", int type = 0)
		{
			return Client.GetCommand("location/line/bus_route",
				string.IsNullOrEmpty(beginPID) ? new WeiboStringParameter("begin_coordinate", beginCoordinate) : new WeiboStringParameter("begin_pid", beginPID),
				string.IsNullOrEmpty(endPID) ? new WeiboStringParameter("end_coordinate", endCoordinate) : new WeiboStringParameter("end_pid", endPID),
				new WeiboStringParameter("type", type));
		}

		public string BusLine(string q, string city = "", int page = 1, int count = 10)
		{
			return Client.GetCommand("location/line/bus_line", 
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("city", city),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("count", count));
		}

		public string BusStation(string q, string city = "", int page = 1, int count = 10)
		{

			return Client.GetCommand("location/line/bus_station",
				new WeiboStringParameter("q", q),
				new WeiboStringParameter("city", city),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("count", count));
		}


	}
}
