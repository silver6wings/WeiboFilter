using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codeplex.Data;

namespace NetDimension.Weibo.Interface.Dynamic
{
	/// <summary>
	/// Location接口
	/// </summary>
	public class LocationInterface : WeiboInterface
	{
		LocationAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public LocationInterface(Client client)
			: base(client)
		{
			api = new LocationAPI(client);
		}

		/// <summary>
		/// 生成一张静态的地图图片 
		/// </summary>
		/// <param name="center">中心点坐标，经度纬度用逗号分隔，与城市代码两者必选其一，中心点坐标优先。 </param>
		/// <param name="city">城市代码，与中心点坐标两者必选其一，中心点坐标优先</param>
		/// <param name="coordinates">地图上标点的坐标串，经度纬度用逗号分隔，多个坐标间用“|”分隔，最多不超过10个。示例：coordinates=120.0358,23.1014|116.0358,38.1014。 </param>
		/// <param name="names">地图上标点的名称串，多个名称用逗号分隔，最多不超过10个，数量必须与coordinates参数一致，超出的无效。</param>
		/// <param name="offsetX">x轴偏移方向，东移为正，西移为负，偏移单位为1/4图片宽度，示例：offset_x=1，地图向右移动1/4。 </param>
		/// <param name="offsetY">y轴偏移方向，北移为正，南移为负，偏移单位为1/4图片高度，示例：offset_y=1，地图向上移动1/4。 </param>
		/// <param name="font">字体格式，参数形式为：”字体,字体风格,字号,字体颜色,背景颜色,是否有背景“，其中是否有背景（0：无，1：有），示例：font=宋体,1,20,0XFF0C0C,0XFFFF00,1，默认值为“宋体,1,20,0XFF0CC0,0XFFFFE0,1”，字号最大不超过72号字，如果coordinates参数不存在则font参数无效。 </param>
		/// <param name="lines">在地图中画一条线，参数形式为：“线的颜色,线的宽度,线的拐点坐标”，拐点坐标经度纬度用逗号分隔，多个坐标间用“|”分隔，最多不超过10个，示例：lines=0XFF0000,2,116.32,39.96|116.12,39.96，取值范围为：线的宽度0-50。 </param>
		/// <param name="polygons">在地图中画一个多边形，参数形式为：“边框颜色,边框宽度,填充颜色,填充透明度,多边形的拐点坐标”，拐点坐标经度纬度用逗号分隔，多个坐标间用“|”分隔，最多不超过10个，示例：polygons=0XFF0000,1,0XFF0000,50,116.32,39.96|116.12,39.96|116.32,39.86，取值范围：边框宽度0-50，默认为1、填充透明度0（透明）-100（不透明），默认为50。 </param>
		/// <param name="size">生成的地图大小，格式为宽×高，最大值为800，默认为240，示例：size=480×360。 </param>
		/// <param name="format">生成的地图的图片格式，支持png、jpg等格式，参数全部为小写，默认为png。 </param>
		/// <param name="zoom">地图焦距等级，取值范围为1-17，默认为自适应大小。</param>
		/// <param name="scale">是否显示比例尺，true：是，false：否。 </param>
		/// <param name="traffic">是否需要叠加实际交通地图，true：是，false：否。 </param>
		/// <returns></returns>
		public dynamic GetMapImage(string center="", string city="", string coordinates = "", string names = null, string offsetX = "", string offsetY = "", string font = "", string lines = "", string polygons = "", string size = "240×240", string format = "png", string zoom = "", bool scale = false, bool traffic = false)
		{
			return DynamicJson.Parse(api.GetMapImage(center, city, coordinates, names, offsetX, offsetY, font, lines, polygons, size, format, zoom, scale, traffic));
		}

		/// <summary>
		/// 根据IP地址返回地理信息坐标
		/// </summary>
		/// <param name="ip">需要获取坐标的IP地址，最多不超过10个。</param>
		/// <returns></returns>
		public dynamic IPtoGeo(string[] ips)
		{
			return DynamicJson.Parse(api.IPtoGeo(ips));
		}

		/// <summary>
		/// 根据实际地址返回地理信息坐标
		/// </summary>
		/// <param name="address">需要获取坐标的实际地址</param>
		/// <returns></returns>
		public dynamic AddressToGeo(string address)
		{ 
			return DynamicJson.Parse(api.AddressToGeo(address));
		}

		/// <summary>
		/// 根据地理信息坐标返回实际地址
		/// </summary>
		/// <param name="coordinate">需要获取实际地址的坐标，经度纬度用逗号分隔。 </param>
		/// <returns></returns>
		public string GeoToAddress(string coordinate)
		{
			return DynamicJson.Parse(api.GeoToAddress(coordinate));
		}
		/// <summary>
		/// 根据GPS坐标获取偏移后的坐标 
		/// </summary>
		/// <param name="coordinate">需要获取偏移坐标的源坐标，经度纬度用逗号分隔。 </param>
		/// <returns></returns>
		public string GpsToOffset(string coordinate)
		{ 
			return DynamicJson.Parse(api.GpsToOffset(coordinate));
		}
		/// <summary>
		/// 判断地理信息坐标是否是国内坐标 
		/// </summary>
		/// <param name="coordinate">需要判断的坐标，格式：经度,纬度,字符标识|经度,纬度,字符标识。其中经度纬度用逗号分隔，字符标识用于返回结果中的返回值标识。“|”分隔多个坐标。一次最多50个坐标。示例：coordinates=120.035847163,23.1014362572,g1|116.035847163,38.1014362572,g2。 </param>
		/// <returns></returns>
		public dynamic IsDomestic(string coordinates)
		{
			return DynamicJson.Parse(api.IsDomestic(coordinates));
		}
		/// <summary>
		/// 批量获取POI点的信息
		/// </summary>
		/// <param name="srcids">需要获取POI的来源ID，是由用户通过add接口自己提交的，最多不超过5个。 </param>
		/// <returns></returns>
		public dynamic ShowPOIs(string[] srcids)
		{
			return DynamicJson.Parse(api.ShowPOIs(srcids));
		}
		/// <summary>
		/// 根据关键词按地址位置获取POI点的信息 
		/// </summary>
		/// <param name="q">查询的关键词，与category参数必选其一。</param>
		/// <param name="category">查询的分类代码，与q参数必选其一，取值范围见：分类代码对应表。 </param>
		/// <param name="city">城市代码，默认为全国搜索。 </param>
		/// <param name="page">返回结果的页码，默认为1，最大为40。 </param>
		/// <param name="count">单页返回的记录条数，默认为10，最大为20。 </param>
		/// <returns></returns>
		public dynamic SearchPOIsByLocation(string q = "", string category = "", string city = "", int page = 1, int count = 20)
		{
			return DynamicJson.Parse(api.SearchPOIsByLocation(q,category,city,page,count));
		}
		/// <summary>
		/// 根据关键词按坐标点范围获取POI点的信息
		/// </summary>
		/// <param name="q">查询的关键词，与category参数必选其一。</param>
		/// <param name="category">查询的分类代码，与q参数必选其一，取值范围见：分类代码对应表。 </param>
		/// <param name="coordinate">查询的中心点坐标，经度纬度用逗号分隔，与pid参数必选其一，pid优先。 </param>
		/// <param name="pid">查询的中心点POI的ID，与coordinate参数必选其一，pid优先。 </param>
		/// <param name="city">城市代码，默认为全国搜索。 </param>
		/// <param name="range">查询范围半径，默认为500，最大为500。 </param>
		/// <param name="page">返回结果的页码，默认为1，最大为40。 </param>
		/// <param name="count">单页返回的记录条数，默认为10，最大为20。 </param>
		/// <returns></returns>
		public dynamic SearchPOIsByGeo(string q = "", string category = "", string coordinate = "", string pid = "", string city = "", int range = 500, int page = 1, int count = 20)
		{
			return DynamicJson.Parse(api.SearchPOIsByGeo(q,category,coordinate,pid,city,range,page,count));
		}
		/// <summary>
		/// 根据关键词按矩形区域获取POI点的信息
		/// </summary>
		/// <param name="q">查询的关键词，与category参数必选其一。</param>
		/// <param name="category">查询的分类代码，与q参数必选其一，取值范围见：分类代码对应表。 </param>
		/// <param name="coordinates">查询的矩形区域坐标，第一个坐标为左上角的点，第二个为右下角，经度纬度用逗号分隔，坐标间用“|”分隔，示例：coordinates=116.37,39.93|116.43,39.91。 </param>
		/// <param name="city">城市代码，默认为全国搜索。 </param>
		/// <param name="page">返回结果的页码，默认为1，最大为40。 </param>
		/// <param name="count">单页返回的记录条数，默认为10，最大为20。 </param>
		/// <returns></returns>
		public dynamic SearchPOIsByArea(string q = "", string category = "", string coordinates = "", string city = "", int page = 1, int count = 20)
		{
			return DynamicJson.Parse(api.SearchPOIsByArea(q,category,coordinates,city,page,count));
		}
		/// <summary>
		/// 提交一个新增的POI点信息 
		/// </summary>
		/// <param name="srcid">来源ID，用户自己设置，用于取回自己提交的POI信息，为2-8位的数字。 </param>
		/// <param name="name">POI点的名称，不超过30个字符</param>
		/// <param name="address">POI点的地址，不超过60个字符</param>
		/// <param name="cityName">POI点的城市中文名称，不超过30个字符</param>
		/// <param name="category">POI点的类别中文名称，不超过30个字符</param>
		/// <param name="longitude">POI点的经度，2-15个字符</param>
		/// <param name="latitude">POI点的维度，2-15个字符</param>
		/// <param name="phone">POI点的电话</param>
		/// <param name="picUrl">POI点的图片地址</param>
		/// <param name="url">POI点的网址</param>
		/// <param name="tags">POI点的标签，多个标签之间用逗号分隔，不超过60个字符</param>
		/// <param name="description">POI点的介绍，不超过120个字符</param>
		/// <param name="intro">POI点的其他特色信息，不超过120个字符，可以以JSON字符串方式提交</param>
		/// <param name="traffic">POI点的交通情况描述，不超过120个字符</param>
		/// <returns></returns>
		public dynamic AddPOI(string srcid, string name, string address, string cityName, string category, string longitude, string latitude, string phone = "", string picUrl = "", string url = "", string tags = "", string description = "", string intro = "", string traffic = "")
		{
			return DynamicJson.Parse(api.AddPOI(srcid,name,address,cityName,category,longitude,latitude,phone,picUrl,url,tags,description,intro,traffic));
		}
		/// <summary>
		/// 根据移动基站WIFI等数据获取当前位置信息
		/// </summary>
		/// <param name="json">特殊的JSON参数形式</param>
		/// <returns></returns>
		public dynamic GetLocationByMobileStation(string json)
		{
			return DynamicJson.Parse(api.GetLocationByMobileStation(json));
		}
		/// <summary>
		/// 根据起点与终点数据查询自驾车路线信息 
		/// </summary>
		/// <param name="beginPID">查询起点POI的ID，与begin_coordinate参数必选其一，begin_pid优先。</param>
		/// <param name="beginCoordinate">查询起点的坐标，经度纬度用逗号分隔，与begin_pid参数必选其一，begin_pid优先。 </param>
		/// <param name="endPID">查询终点POI的ID，与end_coordinate参数必选其一，end_pid优先。 </param>
		/// <param name="endCoordinate">查询终点的坐标，经度纬度用逗号分隔，与end_pid参数必选其一，end_pid优先。 </param>
		/// <param name="type">查询类型，0：速度优先、1：费用优先、2：距离优先，默认值为0。 </param>
		/// <returns></returns>
		public dynamic DriveRouteLine(string beginPID = "", string beginCoordinate = "", string endPID = "", string endCoordinate = "", int type = 0)
		{
			return DynamicJson.Parse(api.DriveRouteLine(beginPID,beginCoordinate,endPID,endCoordinate,type));
		}

		/// <summary>
		/// 根据起点与终点数据查询公交乘坐路线信息 
		/// </summary>
		/// <param name="beginPID">查询起点POI的ID，与begin_coordinate参数必选其一，begin_pid优先。</param>
		/// <param name="beginCoordinate">查询起点的坐标，经度纬度用逗号分隔，与begin_pid参数必选其一，begin_pid优先。 </param>
		/// <param name="endPID">查询终点POI的ID，与end_coordinate参数必选其一，end_pid优先。 </param>
		/// <param name="endCoordinate">查询终点的坐标，经度纬度用逗号分隔，与end_pid参数必选其一，end_pid优先。 </param>
		/// <param name="type">查询类型，0：速度优先、1：费用优先、2：距离优先，默认值为0。 </param>
		/// <returns></returns>
		public dynamic BusRouteLine(string beginPID = "", string beginCoordinate = "", string endPID = "", string endCoordinate = "", int type = 0)
		{
			return DynamicJson.Parse(api.BusRouteLine(beginPID, beginCoordinate, endPID, endCoordinate, type));
		}
		/// <summary>
		/// 根据关键词查询公交线路信息 
		/// </summary>
		/// <param name="q">查询的关键词</param>
		/// <param name="city">城市代码，默认为北京搜索。 </param>
		/// <param name="page">返回结果的页码，默认为1，最大为40。 </param>
		/// <param name="count">单页返回的记录条数，默认为10，最大为50。 </param>
		/// <returns></returns>
		public dynamic BusLine(string q, string city = "", int page = 1, int count = 10)
		{
			return DynamicJson.Parse(api.BusLine(q,city,page,count));
		}
		/// <summary>
		/// 根据关键词查询公交站点信息 
		/// </summary>
		/// <param name="q">查询的关键词</param>
		/// <param name="city">城市代码，默认为北京搜索。 </param>
		/// <param name="page">返回结果的页码，默认为1，最大为40。 </param>
		/// <param name="count">单页返回的记录条数，默认为10，最大为50。 </param>
		/// <returns></returns>
		public dynamic BusStation(string q, string city = "", int page = 1, int count = 10)
		{
			return DynamicJson.Parse(api.BusStation(q, city, page, count));
		}

	}
}
