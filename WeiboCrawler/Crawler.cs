using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetDimension.Weibo;

namespace WeiboCrawler
{
    class Crawler
    {
        Client sina;

        public Crawler()
        {
            sina = OAuther.getOAuth();
            if (sina == null) return;
            Console.WriteLine("=== Crawler Initlization Over ===");
        }

        public User getUserInfo(string userName)
        {
            User userInfo = null;
            try
            {
                userInfo = User.CreateByAPI(sina.API.Entity.Users.Show(null, userName));
                Console.WriteLine(userInfo.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("{0}", ex.GetType().Name);
                Console.WriteLine("{0}", ex.Message);
            }
            return userInfo;
        }

        public void getUserStatus(string userName)
        {

        }
    }
}
