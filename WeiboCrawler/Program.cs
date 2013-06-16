using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

using PanGu;
using PanGu.Dict;

namespace WeiboTools
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== START ===");

            //keepWatchingPhotos("silver6wings", 5);
            //fetchStatus("银翎六翼");

            fetchUserStatusInFile("UserList.txt", 200);

            Console.WriteLine("=== END ===");
            Console.ReadKey();
        }

        public static void fetchUserStatusInFile(string listName, int topMax)
        {
            string listPath = Properties.Crawler.Default.basePath + listName;

            StreamReader sr = new StreamReader(listPath);

            string userName = "";
            while(!string.IsNullOrEmpty(userName = sr.ReadLine())){
                Console.WriteLine(userName);
                fetchUserStatus(userName, topMax);
            }
            sr.Close();
        }

        public static void fetchUserStatus(string userName, int topMax)
        {
            // 找到用户名对应的文件
            string filePath = Properties.Crawler.Default.weiboPath + userName + ".txt";

            // 找到用户最新的微博ID
            long max = long.MinValue;

            Recorder rr = new Recorder(false);
            if(File.Exists(filePath))
            {
                rr.ReadStream(filePath);
                Status ts = (Status)rr.ReadObject();
                while (ts != null)
                {
                    if (max < long.Parse(ts.ID)) max = long.Parse(ts.ID);
                    ts = (Status)rr.ReadObject();
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

        public static void keepWatchingPhotos(string userName, int watchLength)
        {
            Crawler cr = new Crawler();
            int i = 0;

            // 每小时限制150次API，每24秒一次call
            while (true)
            {
                Console.WriteLine(DateTime.Now + " Watching..." + ++i);
                List<Status> ls = cr.getUserStatusByUserName(userName, watchLength);
                foreach (Status s in ls) Downloader.getStatusPictures(s);
                Thread.Sleep(24000);
            }
        }

    }
}