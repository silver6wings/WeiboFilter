using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;
namespace NetDimension.Weibo.Entities.user
{
	public class Entity : EntityBase
	{
		//[JsonProperty(PropertyName = "id")]
		//public string ID{get;internal set;}
		//[JsonProperty(PropertyName = "screen_name")]
		//public string ScreenName{get;internal set;}
		//[JsonProperty(PropertyName = "name")]
		//public string Name{get;internal set;}
		//[JsonProperty(PropertyName = "province")]
		//public string Province{get;internal set;}
		//[JsonProperty(PropertyName = "city")]
		//public string City { get; internal set; }
		//[JsonProperty(PropertyName = "location")]
		//public string Location { get; internal set; }
		//[JsonProperty(PropertyName = "description")]
		//public string Description { get; internal set; }
		//[JsonProperty(PropertyName = "url")]
		//public string Url { get; internal set; }
		//[JsonProperty(PropertyName = "profile_image_url")]
		//public string ProfileImageUrl { get; internal set; }
		//[JsonProperty(PropertyName = "domain")]
		//public string Domain { get; internal set; }
		//[JsonProperty(PropertyName = "gender")]
		//public string Gender { get; internal set; }
		//[JsonProperty(PropertyName = "followers_count")]
		//public int FollowersCount { get; internal set; }
		//[JsonProperty(PropertyName = "friends_count")]
		//public int FriendsCount { get; internal set; }
		//[JsonProperty(PropertyName = "statuses_count")]
		//public int StatusesCount { get; internal set; }
		//[JsonProperty(PropertyName = "favourites_count")]
		//public long FavouritesCount { get; internal set; }
		//[JsonProperty(PropertyName = "created_at")]
		//public string CreatedAt { get; internal set; }
		//[JsonProperty(PropertyName = "following")]
		//public bool Following { get; internal set; }
		//[JsonProperty(PropertyName = "allow_all_act_msg")]
		//public bool AllowAllActMsg { get; internal set; }
		//[JsonProperty(PropertyName = "remark")]
		//public string Remark { get; internal set; }
		//[JsonProperty(PropertyName = "geo_enabled")]
		//public bool GEOEnabled { get; internal set; }
		//[JsonProperty(PropertyName = "verified")]
		//public bool Verified { get; internal set; }
		//[JsonProperty(PropertyName = "allow_all_comment")]
		//public bool AllowAllComment { get; internal set; }
		//[JsonProperty(PropertyName = "avatar_large")]
		//public string AvatarLarge { get; internal set; }
		//[JsonProperty(PropertyName = "verified_reason")]
		//public string VerifiedReason { get; internal set; }
		//[JsonProperty(PropertyName = "follow_me")]
		//public bool FollowMe { get; internal set; }
		//[JsonProperty(PropertyName = "online_status")]
		//public int OnlineStatus { get; internal set; }
		//[JsonProperty(PropertyName = "bi_followers_count")]
		//public int BIFollowersCount { get; internal set; }
		//[JsonProperty(PropertyName = "status")]
		//public status.Entity Status { get; internal set; }
		/// <summary>
		/// 用户UID
		/// </summary>
		[JsonProperty(PropertyName = "id")]
		public string ID { get; internal set; }
		/// <summary>
		/// 用户UID(字符型)
		/// </summary>
		[JsonProperty(PropertyName = "idstr")]
		public string IDStr { get; internal set; }
		/// <summary>
		/// 用户昵称
		/// </summary>
		[JsonProperty(PropertyName = "screen_name")]
		public string ScreenName { get; internal set; }
		/// <summary>
		/// 友好显示名称
		/// </summary>
		[JsonProperty(PropertyName = "name")]
		public string Name { get; internal set; }
		/// <summary>
		/// 用户所在地区ID
		/// </summary>
		[JsonProperty(PropertyName = "province")]
		public string Province { get; internal set; }
		/// <summary>
		/// 用户所在城市ID
		/// </summary>
		[JsonProperty(PropertyName = "city")]
		public string City { get; internal set; }
		/// <summary>
		/// 用户所在地
		/// </summary>
		[JsonProperty(PropertyName = "location")]
		public string Location { get; internal set; }
		/// <summary>
		/// 用户描述
		/// </summary>
		[JsonProperty(PropertyName = "description")]
		public string Description { get; internal set; }
		/// <summary>
		/// 用户博客地址
		/// </summary>
		[JsonProperty(PropertyName = "url")]
		public string Url { get; internal set; }
		/// <summary>
		/// 用户头像地址
		/// </summary>
		[JsonProperty(PropertyName = "profile_image_url")]
		public string ProfileImageUrl { get; internal set; }
		/// <summary>
		/// 用户微博主页地址
		/// </summary>
		[JsonProperty(PropertyName = "profile_url")]
		public string ProfileUrl { get; internal set; }
		/// <summary>
		/// 用户的个性化域名
		/// </summary>
		[JsonProperty(PropertyName = "domain")]
		public string Domain { get; internal set; }
		/// <summary>
		/// 用户的微号
		/// </summary>
		[JsonProperty(PropertyName = "weihao")]
		public string Weihao { get; internal set; }
		/// <summary>
		/// 性别，m：男、f：女、n：未知
		/// </summary>
		[JsonProperty(PropertyName = "gender")]
		public string Gender { get; internal set; }
		/// <summary>
		/// 粉丝数
		/// </summary>
		[JsonProperty(PropertyName = "followers_count")]
		public int FollowersCount { get; internal set; }
		/// <summary>
		/// 关注数
		/// </summary>
		[JsonProperty(PropertyName = "friends_count")]
		public int FriendsCount { get; internal set; }
		/// <summary>
		/// 微博数
		/// </summary>
		[JsonProperty(PropertyName = "statuses_count")]
		public int StatusesCount { get; internal set; }
		/// <summary>
		/// 收藏数
		/// </summary>
		[JsonProperty(PropertyName = "favourites_count")]
		public long FavouritesCount { get; internal set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty(PropertyName = "created_at")]
		public string CreatedAt { get; internal set; }
		/// <summary>
		/// 当前登录用户是否已关注该用户
		/// </summary>
		[JsonProperty(PropertyName = "following")]
		public bool Following { get; internal set; }
		/// <summary>
		/// 是否允许所有人给我发私信
		/// </summary>
		[JsonProperty(PropertyName = "allow_all_act_msg")]
		public bool AllowAllActMsg { get; internal set; }
		/// <summary>
		/// 是否允许带有地理信息
		/// </summary>
		[JsonProperty(PropertyName = "geo_enabled")]
		public bool GEOEnabled { get; internal set; }
		/// <summary>
		/// 是否是微博认证用户，即带V用户
		/// </summary>
		[JsonProperty(PropertyName = "verified")]
		public bool Verified { get; internal set; }
		/// <summary>
		/// 微博认证用户的类型
		/// </summary>
		[JsonProperty(PropertyName = "verified_type")]
		public string VerifiedType { get; internal set; }
		/// <summary>
		/// 备注信息
		/// </summary>
		[JsonProperty(PropertyName = "remark")]
		public string Remark { get; internal set; }
		/// <summary>
		/// 用户的最近一条微博信息字段
		/// </summary>
		[JsonProperty(PropertyName = "status")]
		public status.Entity Status { get; internal set; }
		/// <summary>
		/// 是否允许所有人对我的微博进行评论
		/// </summary>
		[JsonProperty(PropertyName = "allow_all_comment")]
		public bool AllowAllComment { get; internal set; }
		/// <summary>
		/// 用户大头像地址
		/// </summary>
		[JsonProperty(PropertyName = "avatar_large")]
		public string AvatarLarge { get; internal set; }
		/// <summary>
		/// 认证原因
		/// </summary>
		[JsonProperty(PropertyName = "verified_reason")]
		public string VerifiedReason { get; internal set; }
		/// <summary>
		/// 该用户是否关注当前登录用户
		/// </summary>
		[JsonProperty(PropertyName = "follow_me")]
		public bool FollowMe { get; internal set; }
		/// <summary>
		/// 用户的在线状态，0：不在线、1：在线
		/// </summary>
		[JsonProperty(PropertyName = "online_status")]
		public int OnlineStatus { get; internal set; }
		/// <summary>
		/// 用户的互粉数
		/// </summary>
		[JsonProperty(PropertyName = "bi_followers_count")]
		public int BIFollowersCount { get; internal set; }
		/// <summary>
		/// 用户使用语言类型
		/// </summary>
		[JsonProperty(PropertyName = "lang")]
		public string Lang { get; internal set; }
	}
}
