using System;
using System.Collections.Generic;

using System.Text;
using System.Web;
using NetDimension.Json;
using NetDimension.Json.Linq;
using NetDimension.Weibo.Entities;
namespace NetDimension.Weibo.Interface.Entity
{
	/// <summary>
	/// Common接口
	/// </summary>
	public class CommonInterface: WeiboInterface
	{
		CommonAPI api;
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
		public Dictionary<string, string> CodeToLocation(params string[] codes)
		{

			return Utility.GetDictionaryFromJSON(api.CodeToLocation(codes));
		}
		/// <summary>
		/// 获取城市列表
		/// </summary>
		/// <param name="province">省份的省份代码。</param>
		/// <param name="capital">城市的首字母，a-z，可为空代表返回全部，默认为全部。</param>
		/// <returns></returns>
		public Dictionary<string, string> GetCity(string province, string capital = "")
		{
			return Utility.GetDictionaryFromJSON(api.GetCity(province, capital));
		}
		/// <summary>
		/// 获取省份列表 
		/// </summary>
		/// <param name="country">国家的国家代码。</param>
		/// <param name="capital">省份的首字母，a-z，可为空代表返回全部，默认为全部。 </param>
		/// <returns></returns>
		public Dictionary<string, string> GetProvince(string country, string capital = "")
		{
			return Utility.GetDictionaryFromJSON(api.GetProvince(country, capital));
		}
		/// <summary>
		/// 获取国家列表 
		/// </summary>
		/// <param name="capital">国家的首字母，a-z，可为空代表返回全部，默认为全部。</param>
		/// <returns></returns>
		public Dictionary<string, string> GetCountry(string capital = "")
		{
			return Utility.GetDictionaryFromJSON(api.GetCountry(capital));
		}
		/// <summary>
		/// 获取时区配置表
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, string> GetTimezone()
		{
			return Utility.GetDictionaryFromJSON(api.GetTimezone());
		}

	}
}
