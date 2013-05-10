using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiboCrawler
{
    [Serializable()]
    class User
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

        public static User CreateByAPI(NetDimension.Weibo.Entities.user.Entity userInfo){

            User myUserInfo = new User();

            myUserInfo.ID =             userInfo.ID;
            myUserInfo.Name =           userInfo.Name;
            myUserInfo.Province =       userInfo.Province; 
            myUserInfo.City =           userInfo.City;
            myUserInfo.Location =       userInfo.Location;
            myUserInfo.Description =    userInfo.Description;
            myUserInfo.Gender =         userInfo.Gender;

            myUserInfo.FollowersCount = userInfo.FollowersCount;
            myUserInfo.FriendsCount =   userInfo.FriendsCount;
            myUserInfo.StatusesCount =  userInfo.StatusesCount;

            myUserInfo.Verified =       userInfo.Verified;
            myUserInfo.VerifiedType =   userInfo.VerifiedType;
            myUserInfo.Lang =           userInfo.Lang;

            return myUserInfo;
        }
    }
}
