using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	internal class CommentAPI: WeiboAPI
	{
		public CommentAPI(Client client)
			: base(client)
		{

		}

		/// <summary>
		/// 根据微博ID返回某条微博的评论列表
		/// </summary>
		/// <param name="id">需要查询的微博ID。</param>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="filterByAuthor">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
		/// <returns>JSON</returns>
		public string Show(string id, string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0)
		{
			return (Client.GetCommand("comments/show",
				new WeiboStringParameter("id", id),
				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("filter_by_author", filterByAuthor)));
		}
		/// <summary>
		/// 获取当前登录用户所发出的评论列表
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="filterBySource">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。 </param>
		/// <returns></returns>
		public string ByMe(string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterBySource = 0)
		{
			return (Client.GetCommand("comments/by_me",

				new WeiboStringParameter("since_id", sinceID),
				new WeiboStringParameter("max_id", maxID),
				new WeiboStringParameter("count", count),
				new WeiboStringParameter("page", page),
				new WeiboStringParameter("filter_by_source", filterBySource)));
		}
		/// <summary>
		/// 获取当前登录用户所接收到的评论列表
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
		/// <param name="count">单页返回的记录条数，默认为50。</param>
		/// <param name="page">返回结果的页码，默认为1。</param>
		/// <param name="filterByAuthor">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。 </param>
		/// <param name="filterBySource"></param>
		/// <returns></returns>
		public string ToMe(string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0, int filterBySource = 0)
		{
			return (Client.GetCommand("comments/to_me",
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("filter_by_author", filterByAuthor),
					new WeiboStringParameter("filter_by_source", filterBySource)));
		}
		/// <summary>
		/// 获取当前登录用户的最新评论包括接收到的与发出的
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <returns>JSON</returns>
		public string Timeline(string sinceID = "", string maxID = "", int count = 50, int page = 1)
		{
			return (Client.GetCommand("comments/timeline",
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page)));
		}
		/// <summary>
		/// 获取最新的提到当前登录用户的评论，即@我的评论 
		/// </summary>
		/// <param name="sinceID">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
		/// <param name="maxID">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。 </param>
		/// <param name="count">单页返回的记录条数，默认为50。 </param>
		/// <param name="page">返回结果的页码，默认为1。 </param>
		/// <param name="filterByAuthor">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。 </param>
		/// <param name="filterBySource">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
		/// <returns></returns>
		public string Mentions(string sinceID = "", string maxID = "", int count = 50, int page = 1, int filterByAuthor = 0, int filterBySource = 0)
		{
			return (Client.GetCommand("comments/mentions",
					new WeiboStringParameter("since_id", sinceID),
					new WeiboStringParameter("max_id", maxID),
					new WeiboStringParameter("count", count),
					new WeiboStringParameter("page", page),
					new WeiboStringParameter("filter_by_author", filterByAuthor),
					new WeiboStringParameter("filter_by_source", filterBySource)));
		}

		/// <summary>
		/// 根据评论ID批量返回评论信息
		/// </summary>
		/// <param name="cids">需要查询的批量评论ID，最大50。</param>
		/// <returns></returns>
		public string ShowBatch(params string[] cids)
		{
			return (Client.GetCommand("comments/show_batch",
				new WeiboStringParameter("cids", string.Join(",", cids))));
		}

		/// <summary>
		/// 对一条微博进行评论
		/// </summary>
		/// <param name="id">需要评论的微博ID。</param>
		/// <param name="comment">评论内容，必须做URLencode，内容不超过140个汉字。 </param>
		/// <param name="commentOrigin">当评论转发微博时，是否评论给原微博，0：否、1：是，默认为0。 </param>
		/// <returns></returns>
		public string Create(string id, string comment, bool commentOrigin = false)
		{
			return (Client.PostCommand("comments/create",
				new WeiboStringParameter("id", id),
				new WeiboStringParameter("comment", comment),
				new WeiboStringParameter("comment_ori", commentOrigin)));
		}
		/// <summary>
		/// 删除一条评论 
		/// </summary>
		/// <param name="cid">要删除的评论ID，只能删除登录用户自己发布的评论。 </param>
		/// <returns></returns>
		public string Destroy(string cid)
		{
			return (Client.PostCommand("comments/destroy",
				new WeiboStringParameter("cid", cid)));
		}

		/// <summary>
		/// 根据评论ID批量删除评论 
		/// </summary>
		/// <param name="ids">需要删除的评论ID，最多20个。 </param>
		/// <returns></returns>
		public string DestroyBatch(params string[] ids)
		{
			return (Client.PostCommand("comments/destroy",
					new WeiboStringParameter("destroy_batch", string.Join(",", ids))));
		}
		/// <summary>
		/// 回复一条评论 
		/// </summary>
		/// <param name="cid">需要回复的评论ID。</param>
		/// <param name="id">需要评论的微博ID。</param>
		/// <param name="comment">回复评论内容，必须做URLencode，内容不超过140个汉字。 </param>
		/// <param name="withoutMention">回复中是否自动加入“回复@用户名”，0：是、1：否，默认为0。 </param>
		/// <param name="commentOrigin">当评论转发微博时，是否评论给原微博，0：否、1：是，默认为0。 </param>
		/// <returns></returns>
		public string Reply(string cid, string id, string comment, bool withoutMention = false, bool commentOrigin = false)
		{
			return (Client.PostCommand("comments/reply",
				new WeiboStringParameter("cid", cid),
				new WeiboStringParameter("id", id),
				new WeiboStringParameter("comment", comment),
				new WeiboStringParameter("without_mention", withoutMention),
				new WeiboStringParameter("comment_ori", commentOrigin)));
		}

	}
}
