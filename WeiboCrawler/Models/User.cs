using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiboCrawler
{
    [Serializable()]
    public class User
    {
        public string ID { get; internal set; }             // 用户ID
        public string Name { get; internal set; }           // 用户昵称
        public string Province { get; internal set; }       // 用户所在地区ID
        public string City { get; internal set; }           // 用户所在城市ID
        public string Location { get; internal set; }       // 用户所在地
        public string Description { get; internal set; }    // 用户描述     
        public string Gender { get; internal set; }
       
        public int FollowersCount { get; internal set; }
        public int FriendsCount { get; internal set; }
        public int StatusesCount { get; internal set; }
       
        public bool Verified { get; internal set; }
        public string VerifiedType { get; internal set; }
        public string Lang { get; internal set; }

        public User(NetDimension.Weibo.Entities.user.Entity userInfo){
            this.ID =             userInfo.ID;
            this.Name =           userInfo.Name;
            this.Province =       userInfo.Province; 
            this.City =           userInfo.City;
            this.Location =       userInfo.Location;
            this.Description =    userInfo.Description;
            this.Gender =         userInfo.Gender;

            this.FollowersCount = userInfo.FollowersCount;
            this.FriendsCount =   userInfo.FriendsCount;
            this.StatusesCount =  userInfo.StatusesCount;

            this.Verified =       userInfo.Verified;
            this.VerifiedType =   userInfo.VerifiedType;
            this.Lang =           userInfo.Lang;
        }
    }
}
