using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

using Silver6wings.WeiboTools;

namespace Silver6wings.WeiboCollector
{
    public class WeiboCollector
    {

        public static void Main()
        {
            Console.WriteLine("=== START ===");

            fetchUserStatusInFile("../_Data/UserListNew.txt", "../_Data/Weibo/Database.txt", 50);

            Console.WriteLine("=== END ===");
            Console.ReadKey();
        }

        public static void fetchUserStatusInFile(string listPath, string toPath, int topMax)
        {
            // 关注所有的list
            Crawler crawler = new Crawler();
            //crawler.followUserByUserList(listPath);

            // 找到用户最新的微博ID
            long max = long.MinValue;

            Recorder rr = new Recorder(false);
            if (File.Exists(toPath))
            {
                rr.ReadStream(toPath);
                Status ts = (Status)rr.ReadNextObject();
                while (ts != null)
                {
                    if (max < long.Parse(ts.ID)) max = long.Parse(ts.ID);
                    ts = (Status)rr.ReadNextObject();
                }
                rr.CloseStream();
            }

            // 用依然可以使用的Home_Timeline获取最新的一大串微博
            rr.WriteStream(toPath);
            int count = 0, page = 1, numOfRecord = 0;      
     
            while(count < topMax){
                int need = Math.Min(topMax - count, 100);
                Console.WriteLine(need);

                List<Status> ls = crawler.getUserStatusByHome(need, page);

                foreach (Status s in ls)
                {
                    // 如果是最新的就写入到记录文件中
                    if (max < long.Parse(s.ID))
                    {
                        rr.WriteObject(s);
                        Console.WriteLine(s.ID);
                        numOfRecord++;
                    }
                }

                count += need;
                page++;
            }
            rr.CloseStream();

            Console.WriteLine(numOfRecord + " recorded");
        }

        // 新版微博API已经禁止未审核的应用来访问其他用户的User_TimeLine
        [Obsolete] 
        public static void fetchUserStatus(string userName, int topMax)
        {
            // 找到用户名对应的文件
            string filePath = Properties.Collector.Default.weiboPath + userName + ".txt";

            // 找到用户最新的微博ID
            long max = long.MinValue;

            Recorder rr = new Recorder(false);
            if(File.Exists(filePath))
            {
                rr.ReadStream(filePath);
                Status ts = (Status)rr.ReadNextObject();
                while (ts != null)
                {
                    if (max < long.Parse(ts.ID)) max = long.Parse(ts.ID);
                    ts = (Status)rr.ReadNextObject();
                }
                rr.CloseStream();
            }

            // 抓用户最新的微博
            Crawler cr = new Crawler();
            List<Status> ls = cr.getUserStatusByUserName(userName, topMax, 1);

            rr.WriteStream(filePath);
            foreach (Status s in ls)
            {
                // 如果是最新的就写入到记录文件中
                if (max < long.Parse(s.ID))
                {
                    rr.WriteObject(s);
                    Console.WriteLine(s.ID);
                }
            }
            rr.CloseStream();
        }

        // 新版微博API已经禁止未审核的应用来访问其他用户的User_TimeLine
        [Obsolete]
        public static void keepWatchingPhotos(string userName, int watchLength)
        {
            Crawler cr = new Crawler();
            int i = 0;

            // 每小时限制150次API，每24秒一次call
            while (true)
            {
                Console.WriteLine(DateTime.Now + " Watching..." + ++i);
                List<Status> ls = cr.getUserStatusByUserName(userName, watchLength);
                foreach (Status s in ls) Downloader.getStatusPictures(s, "../_Data/Pictures");
                Thread.Sleep(24000);
            }
        }
    }
}