using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Codeplex.Data;

namespace NetDimension.Weibo.Interface.Dynamic
{
	/// <summary>
	/// Common接口
	/// </summary>
	public class CommonInterface: WeiboInterface
	{
		CommonAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public CommonInterface(Client client)
			: base(client)
		{
			api = new CommonAPI(client);
		}
		/// <summary>
		/// 通过地址编码获取地址名称 
		/// </summary>
		/// <param name="codes">需要查询的地址编码</param>
		/// <returns></returns>
		public dynamic CodeToLocation(params string[] codes)
		{
			return DynamicJson.Parse(api.CodeToLocation(codes));
		}
		/// <summary>
		/// 获取城市列表
		/// </summary>
		/// <param name="province">省份的省份代码。</param>
		/// <param name="capital">城市的首字母，a-z，可为空代表返回全部，默认为全部。</param>
		/// <returns></returns>
		public dynamic GetCity(string province,string capital= "")
		{
			return DynamicJson.Parse(api.GetCity(province,capital));
		}
		/// <summary>
		/// 获取省份列表 
		/// </summary>
		/// <param name="country">国家的国家代码。</param>
		/// <param name="capital">省份的首字母，a-z，可为空代表返回全部，默认为全部。 </param>
		/// <returns></returns>
		public dynamic GetProvince(string country, string capital = "")
		{
			return DynamicJson.Parse(api.GetProvince(country, capital));
		}
		/// <summary>
		/// 获取国家列表 
		/// </summary>
		/// <param name="capital">国家的首字母，a-z，可为空代表返回全部，默认为全部。</param>
		/// <returns></returns>
		public dynamic GetCountry(string capital = "")
		{
			return DynamicJson.Parse(api.GetCountry(capital));
		}
		/// <summary>
		/// 获取时区配置表
		/// </summary>
		/// <returns></returns>
		public dynamic GetTimezone()
		{
			return DynamicJson.Parse(api.GetTimezone());
		}

	}
}
