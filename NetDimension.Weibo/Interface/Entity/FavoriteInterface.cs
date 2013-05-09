using System;
using System.Collections.Generic;

using System.Text;
using NetDimension.Json;
using NetDimension.Json.Linq;
using NetDimension.Weibo.Entities;
namespace NetDimension.Weibo.Interface.Entity
{
	/// <summary>
	/// Favorite接口
	/// </summary>
	public class FavoriteInterface: WeiboInterface
	{
		FavoriteAPI api;
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作类</param>
		public FavoriteInterface(Client client)
			: base(client)
		{
			api = new FavoriteAPI(client);
		}
		/// <summary>
		/// 获取当前登录用户的收藏列表
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public NetDimension.Weibo.Entities.favorite.Collection Favorites(int count = 50, int page = 1)
		{
			return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.favorite.Collection>(api.Favorites(count, page));
		}
		/// <summary>
		/// 获取当前用户的收藏列表的ID
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public NetDimension.Weibo.Entities.favorite.IDCollection FavoriteIDs(int count = 50, int page = 1)
		{
			return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.favorite.IDCollection>(api.FavoriteIDs(count, page));
		}
		/// <summary>
		/// 根据收藏ID获取指定的收藏信息 
		/// </summary>
		/// <param name="id">需要查询的收藏ID。 </param>
		/// <returns></returns>
		public NetDimension.Weibo.Entities.favorite.Entity Show(string id)
		{
			return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.favorite.Entity>(api.Show(id));
		}
		/// <summary>
		/// 根据标签获取当前登录用户该标签下的收藏列表  
		/// </summary>
		/// <param name="tid">需要查询的标签ID。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public NetDimension.Weibo.Entities.favorite.Collection ByTags(string tid, int count = 50, int page = 1)
		{
			return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.favorite.Collection>(api.ByTags(tid, count, page));
		}
		/// <summary>
		/// 获取当前登录用户的收藏标签列表 
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为10。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public IEnumerable<NetDimension.Weibo.Entities.favorite.TagEntity> Tags(int count = 10, int page = 1)
		{
			JObject result = JObject.Parse(api.Tags(count, page));

			return JsonConvert.DeserializeObject<IEnumerable<NetDimension.Weibo.Entities.favorite.TagEntity>>(result["tags"].ToString());
		}
		/// <summary>
		/// 获取当前用户某个标签下的收藏列表的ID 
		/// </summary>
		/// <param name="tid">需要查询的标签ID。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public IEnumerable<NetDimension.Weibo.Entities.favorite.IDEntity> ByTagIDs(string tid, int count = 50, int page = 1)
		{
			JObject result = JObject.Parse(api.ByTagIDs(tid, count, page));
			return JsonConvert.DeserializeObject<IEnumerable<NetDimension.Weibo.Entities.favorite.IDEntity>>(result["favorites"].ToString());
		}
		/// <summary>
		/// 添加一条微博到收藏里 
		/// </summary>
		/// <param name="id">要收藏的微博ID。</param>
		/// <returns></returns>
		public NetDimension.Weibo.Entities.favorite.Entity Create(string id)
		{
			return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.favorite.Entity>(api.Create(id));
		}
		/// <summary>
		/// 取消收藏一条微博
		/// </summary>
		/// <param name="id">要取消收藏的微博ID。</param>
		/// <returns></returns>
		public NetDimension.Weibo.Entities.favorite.Entity Destroy(string id)
		{
			return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.favorite.Entity>(api.Destroy(id));
			
		}
		/// <summary>
		/// 根据收藏ID批量取消收藏 
		/// </summary>
		/// <param name="ids">要取消收藏的收藏ID最多不超过10个。 </param>
		/// <returns></returns>
		public bool DestroyBatch(params string[] ids)
		{
			return Convert.ToBoolean(JObject.Parse(api.DestroyBatch(ids))["result"]);

		}
		/// <summary>
		/// 更新一条收藏的收藏标签
		/// </summary>
		/// <param name="id">需要更新的收藏ID。</param>
		/// <param name="tags">需要更新的标签内容，最多不超过2条。</param>
		/// <returns></returns>
		public NetDimension.Weibo.Entities.favorite.Entity UpdateTags(string id, params string[] tags)
		{
			return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.favorite.Entity>(api.UpdateTags(id, tags));

		}
		/// <summary>
		/// 更新当前登录用户所有收藏下的指定标签 
		/// </summary>
		/// <param name="tid">需要更新的标签ID</param>
		/// <param name="tag">需要更新的标签内容</param>
		/// <returns></returns>
		public NetDimension.Weibo.Entities.favorite.TagEntity UpdateTagsBatch(string tid, string tag)
		{
			return JsonConvert.DeserializeObject<NetDimension.Weibo.Entities.favorite.TagEntity>(api.UpdateTagsBatch(tid, tag));
		}
		/// <summary>
		/// 删除当前登录用户所有收藏下的指定标签 
		/// </summary>
		/// <param name="tid">需要删除的标签ID</param>
		/// <returns></returns>
		public bool DestroyTags(string[] tid)
		{
			return Convert.ToBoolean(JObject.Parse(api.DestroyTags(tid)));
		}
	}
}
