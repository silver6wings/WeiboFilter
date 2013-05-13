using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace WeiboCrawler
{
    public class Test
    {
        public static void Main()
        {
            Console.WriteLine("=== START ===");

            //keepWatchingPhotos("莉莉努力去哈佛宾大包养小白脸", 5);
            fetchStatus("莉莉努力去哈佛宾大包养小白脸");

            Console.WriteLine("=== END ===");
            Console.ReadKey();
        }

        public static void fetchStatus(string userName)
        {
            // 找到用户名对应的文件
            string filePath = Properties.Crawler.Default.weiboPath + userName + ".txt";

            // 找到用户最新的微博ID
            long max = long.MinValue;

            Recorder rr = new Recorder(false);
            if(File.Exists(filePath))
            {
                rr.ReadStream(filePath);
                Status ts = (Status)rr.readObj();
                while (ts != null)
                {
                    if (max < long.Parse(ts.ID)) max = long.Parse(ts.ID);
                    ts = (Status)rr.readObj();
                }
                rr.CloseStream();
            }

            // 抓用户最新的微博
            Crawler cr = new Crawler();
            List<Status> ls = cr.getUserStatusByUserName(userName, 20, 1);

            rr.WriteStream(filePath);
            foreach (Status s in ls)
            {
                // 如果是最新的就写入到记录文件中
                if (max < long.Parse(s.ID))
                {
                    rr.writeObj(s);
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

