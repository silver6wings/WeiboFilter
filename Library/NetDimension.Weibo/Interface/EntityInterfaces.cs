using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Weibo.Interface.Entity;

namespace NetDimension.Weibo.Interface
{
	/// <summary>
	/// 实体类型类型API接口封装
	/// </summary>
	public class EntityInterfaces
	{
		/// <summary>
		/// 账号接口
		/// </summary>
		public AccountInterface Account { get; private set; }
		/// <summary>
		/// 评论接口
		/// </summary>
		public CommentInterface Comments { get; private set; }
		/// <summary>
		/// 公共服务接口
		/// </summary>
		public CommonInterface Common { get; private set; }
		/// <summary>
		/// 收藏接口
		/// </summary>
		public FavoriteInterface Favorites { get; private set; }
		/// <summary>
		/// 关系接口
		/// </summary>
		public FriendshipInterface Friendships { get; private set; }
		/// <summary>
		/// 搜索接口
		/// </summary>
		public SearchInterface Search { get; private set; }
		/// <summary>
		/// 锻练接口
		/// </summary>
		public ShortUrlInterface ShortUrl { get; private set; }
		/// <summary>
		/// 微博接口
		/// </summary>
		public StatusInterface Statuses { get; private set; }
		/// <summary>
		/// 推荐接口
		/// </summary>
		public SuggestionInterface Suggestions { get; private set; }
		/// <summary>
		/// 标签接口
		/// </summary>
		public TagInterface Tags { get; private set; }
		/// <summary>
		/// 话题接口
		/// </summary>
		public TrendInterface Trends { get; private set; }
		/// <summary>
		/// 用户接口
		/// </summary>
		public UserInterface Users { get; private set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="client">操作器</param>
		public EntityInterfaces(Client client)
		{
			Account = new AccountInterface(client);
			Comments = new CommentInterface(client);
			Common = new CommonInterface(client);
			Favorites = new FavoriteInterface(client);
			Friendships = new FriendshipInterface(client);
			Search = new SearchInterface(client);
			ShortUrl = new ShortUrlInterface(client);
			Statuses = new StatusInterface(client);
			Suggestions = new SuggestionInterface(client);
			Tags = new TagInterface(client);
			Trends = new TrendInterface(client);
			Users = new UserInterface(client);
		}
	}
}
