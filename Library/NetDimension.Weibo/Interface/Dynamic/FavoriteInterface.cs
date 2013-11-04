using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codeplex.Data;

namespace NetDimension.Weibo.Interface.Dynamic
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
		public dynamic Favorites(int count = 50, int page = 1)
		{
			return DynamicJson.Parse(api.Favorites(count,page));
		}
		/// <summary>
		/// 获取当前用户的收藏列表的ID
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns></returns>
		public dynamic FavoriteIDs(int count = 50, int page = 1)
		{
			return DynamicJson.Parse(api.FavoriteIDs(count,page));
		}
		/// <summary>
		/// 根据收藏ID获取指定的收藏信息 
		/// </summary>
		/// <param name="id">需要查询的收藏ID。 </param>
		/// <returns></returns>
		public dynamic Show(string id)
		{
			return DynamicJson.Parse(api.Show(id));
		}
		/// <summary>
		/// 根据标签获取当前登录用户该标签下的收藏列表  
		/// </summary>
		/// <param name="tid">需要查询的标签ID。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public dynamic ByTags(string tid,int count = 50, int page = 1)
		{
			return DynamicJson.Parse(api.ByTags(tid,count,page));
		}
		/// <summary>
		/// 获取当前登录用户的收藏标签列表 
		/// </summary>
		/// <param name="count">单页返回的记录条数，默认为10。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public dynamic Tags(int count = 10, int page = 1)
		{
			return DynamicJson.Parse(api.Tags(count,page));
		}
		/// <summary>
		/// 获取当前用户某个标签下的收藏列表的ID 
		/// </summary>
		/// <param name="tid">需要查询的标签ID。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <returns></returns>
		public dynamic ByTagIDs(string tid, int count = 50, int page = 1)
		{
			return DynamicJson.Parse(api.ByTagIDs(tid,count,page));
		}
		/// <summary>
		/// 添加一条微博到收藏里 
		/// </summary>
		/// <param name="id">要收藏的微博ID。</param>
		/// <returns></returns>
		public dynamic Create(string id)
		{
			return DynamicJson.Parse(api.Create(id));
		}
		/// <summary>
		/// 取消收藏一条微博
		/// </summary>
		/// <param name="id">要取消收藏的微博ID。</param>
		/// <returns></returns>
		public dynamic Destroy(string id)
		{
			return DynamicJson.Parse(api.Destroy(id));
			
		}
		/// <summary>
		/// 根据收藏ID批量取消收藏 
		/// </summary>
		/// <param name="ids">要取消收藏的收藏ID最多不超过10个。 </param>
		/// <returns></returns>
		public dynamic DestroyBatch(params string[] ids)
		{
			return DynamicJson.Parse(api.DestroyBatch(ids));

		}
		/// <summary>
		/// 更新一条收藏的收藏标签
		/// </summary>
		/// <param name="id">需要更新的收藏ID。</param>
		/// <param name="tags">需要更新的标签内容，最多不超过2条。</param>
		/// <returns></returns>
		public dynamic UpdateTags(string id, params string[] tags)
		{
			return DynamicJson.Parse(api.UpdateTags(id,tags));

		}
		/// <summary>
		/// 更新当前登录用户所有收藏下的指定标签 
		/// </summary>
		/// <param name="tid">需要更新的标签ID</param>
		/// <param name="tag">需要更新的标签内容</param>
		/// <returns></returns>
		public dynamic UpdateTagsBatch(string tid, string tag)
		{
			return DynamicJson.Parse(api.UpdateTagsBatch(tid,tag));
		}
		/// <summary>
		/// 删除当前登录用户所有收藏下的指定标签 
		/// </summary>
		/// <param name="tid">需要删除的标签ID</param>
		/// <returns></returns>
		public dynamic DestroyTags(string[] tid)
		{
			return DynamicJson.Parse(api.DestroyTags(tid));
		}
	}
}
