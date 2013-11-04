using System;
using System.Collections.Generic;
using NetDimension.Weibo.Entities;
using System.Text;
using System.Web;
using NetDimension.Json.Linq;


namespace NetDimension.Weibo.Interface.Entity
{
	/// <summary>
	/// Tag接口
	/// </summary>
	public class TagInterface: WeiboInterface
	{
		TagAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public TagInterface(Client client)
			: base(client)
		{
			api = new TagAPI(client);
		}
		/// <summary>
		/// 返回指定用户的标签列表 
		/// </summary>
		/// <param name="uid">要获取的标签列表所属的用户ID。 </param>
		/// <param name="count">单页返回的记录条数，默认为20。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public IEnumerable<Entities.tag.Tag> Tags(string uid, int count = 20, int page = 1)
		{
			var json = JArray.Parse(api.Tags(uid, count, page));
			List<Entities.tag.Tag> list = new List<Entities.tag.Tag>();
			foreach (JObject obj in json)
			{
				var first = (JProperty)obj.First;
				var last = (JProperty)obj.Last;

				list.Add(new Entities.tag.Tag { ID = first.Name, Name = string.Format("{0}", first.Value), Weight = string.Format("{0}", last.Value) });

			}

			return list;
		}
		/// <summary>
		/// 批量获取用户的标签列表 
		/// </summary>
		/// <param name="uids">要获取标签的用户ID。最大20，逗号分隔。 </param>
		/// <returns></returns>
		public Dictionary<string,IEnumerable<Entities.tag.Tag>> TagsBatch(params string[] uids)
		{
			var json = JArray.Parse(api.TagsBatch(uids));
			var result = new Dictionary<string, IEnumerable<Entities.tag.Tag>>();
			foreach (var item in json)
			{
				var entry = item["id"].ToString();
				List<Entities.tag.Tag> list = new List<Entities.tag.Tag>();
				foreach (JObject obj in item["tags"])
				{
					var first = (JProperty)obj.First;
					var last = (JProperty)obj.Last;

					list.Add(new Entities.tag.Tag { ID = first.Name, Name = string.Format("{0}", first.Value), Weight = string.Format("{0}", last.Value) });

				}

				result.Add(entry, list);
				
			}

			return result;
		}
		/// <summary>
		/// 获取系统推荐的标签列表 
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public Dictionary<string,string> Suggestions(int count = 10)
		{ 
			var result = new Dictionary<string,string>();
			var json = JArray.Parse(api.Suggestions(count));
			foreach(JObject x in json)
			{
				result.Add(x["id"].ToString(),x["value"].ToString());
			}
			return result;
		}
		/// <summary>
		/// 为当前登录用户添加新的用户标签 
		/// </summary>
		/// <param name="tags">要创建的一组标签，每个标签的长度不可超过7个汉字，14个半角字符。 </param>
		/// <returns></returns>
		public IEnumerable<string> Create(params string[] tags)
		{
			var json = JArray.Parse(api.Create(tags));
			List<string> ids = new List<string>();
			foreach(JObject x in json)
			{
				ids.Add(x["tagid"].ToString());
			}
			return ids;
		}
		/// <summary>
		/// 删除用户标签 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public string Destroy(string id)
		{
			return JObject.Parse(api.Destroy(id))["result"].ToString();

		}
		/// <summary>
		/// 批量删除用户标签 
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public IEnumerable<string> DestroyBatch(params string[] ids)
		{

			var json = JArray.Parse(api.DestroyBatch(ids));
			List<string> result = new List<string>();
			foreach (JObject x in json)
			{
				result.Add(x["tagid"].ToString());
			}
			return result;
		}
	}
}
