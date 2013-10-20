using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Silver6wings.WeiboTools
{
    public class Crawler
    {
        NetDimension.Weibo.Client sina;

        public Crawler()
        {
            sina = OAuther.getOAuth();
            if (sina == null) return;
            Console.WriteLine("=== Crawler Initlization Over ===");
        }

        public User getUserInfo(string userName)
        {
            User user = null;
            try
            {
                user = new User(sina.API.Entity.Users.Show(null, userName));
                Console.WriteLine(user.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.GetType().Name);
                Console.WriteLine("{0}", ex.Message);
            }
            return user;
        }

        public List<Status> getUserStatusByUserName(string userName, int num = 50, int page = 1)
        {
            Console.WriteLine("Start crawling : " + userName);
            List<Status> myStatusList = new List<Status>();

            try
            {
                var statusList = sina.API.Entity.Statuses.UserTimeline(null, userName, "0", "0", num, page, false, 0, false);
                
                if (statusList.Statuses != null)
                {
                    foreach (var statusInfo in statusList.Statuses)
                    {
                        Status status = new Status(statusInfo);
                        myStatusList.Add(status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.GetType().Name);
                Console.WriteLine("{0}", ex.Message);
            }

            return myStatusList;
        }

        public List<Status> getUserStatusByHome(int num = 50, int page = 1)
        {
            num = Math.Min(num, 200);
            List<Status> myStatusList = new List<Status>();

            try
            {
                var statusList = sina.API.Entity.Statuses.HomeTimeline(null, null, num, page, false, 0);

                if (statusList.Statuses != null)
                {
                    foreach (var statusInfo in statusList.Statuses)
                    {
                        Status status = new Status(statusInfo);
                        myStatusList.Add(status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.GetType().Name);
                Console.WriteLine("{0}", ex.Message);
            }

            return myStatusList;
        }        

        private List<Status> getUserStatusByUserID(string userID)
        {
            List<Status> myStatusList = new List<Status>();
            return myStatusList;
        }

        private void postStatus()
        {
            sina.API.Entity.Statuses.Update("Test");
        }

        public void followUserByName(String userName)
        {
            Console.Write(userName + " ");
            try
            {
                sina.API.Entity.Friendships.Create(null, userName);
                Console.WriteLine("Success");
            }
            catch
            {
                Console.WriteLine("Fail");
            }
        }

        public void followUserByUserList(String listPath)
        {
            StreamReader sr = new StreamReader(listPath);

            string userName = "";
            while (!string.IsNullOrEmpty(userName = sr.ReadLine()))
            {
                this.followUserByName(userName);
            }
            sr.Close();

            Console.WriteLine("Follow finished");
        }

        public void unfollowUserByUserList(String listPath)
        {
            StreamReader sr = new StreamReader(listPath);

            string userName = "";
            while (!string.IsNullOrEmpty(userName = sr.ReadLine()))
            {
                Console.Write(userName + " ");
                try
                {
                    sina.API.Entity.Friendships.Destroy(null, userName);
                    Console.WriteLine("Success");
                }
                catch
                {
                    Console.WriteLine("Fail");
                }
            }
            sr.Close();

            Console.WriteLine("Unfollow finished");
        }
    }
}
