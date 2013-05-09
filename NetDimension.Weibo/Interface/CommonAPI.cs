using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class CommonAPI: WeiboAPI
	{
		public CommonAPI(Client client)
			: base(client)
		{

		}

		/// <summary>
		/// 通过地址编码获取地址名称 
		/// </summary>
		/// <param name="codes">需要查询的地址编码</param>
		/// <returns></returns>
		public string CodeToLocation(params string[] codes)
		{
			return (Client.GetCommand("common/code_to_location", new WeiboStringParameter("codes", string.Join(",", codes))));
		}
		/// <summary>
		/// 获取城市列表
		/// </summary>
		/// <param name="province">省份的省份代码。</param>
		/// <param name="capital">城市的首字母，a-z，可为空代表返回全部，默认为全部。</param>
		/// <returns></returns>
		public string GetCity(string province, string capital = "")
		{
			return (Client.GetCommand("common/get_city",
				new WeiboStringParameter("province", province),
				new WeiboStringParameter("capital", capital)));
		}
		/// <summary>
		/// 获取省份列表 
		/// </summary>
		/// <param name="country">国家的国家代码。</param>
		/// <param name="capital">省份的首字母，a-z，可为空代表返回全部，默认为全部。 </param>
		/// <returns></returns>
		public string GetProvince(string country, string capital = "")
		{
			return (Client.GetCommand("common/get_province",
				new WeiboStringParameter("country", country),
				new WeiboStringParameter("capital", capital)));
		}
		/// <summary>
		/// 获取国家列表 
		/// </summary>
		/// <param name="capital">国家的首字母，a-z，可为空代表返回全部，默认为全部。</param>
		/// <returns></returns>
		public string GetCountry(string capital = "")
		{
			return (Client.GetCommand("common/get_country",
				new WeiboStringParameter("capital", capital)));
		}
		/// <summary>
		/// 获取时区配置表
		/// </summary>
		/// <returns></returns>
		public string GetTimezone()
		{
			return (Client.GetCommand("common/get_timezone"));
		}

	}
}
