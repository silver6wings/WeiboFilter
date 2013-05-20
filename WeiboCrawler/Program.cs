using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

using PanGu;
using PanGu.Dict;

namespace WeiboCrawler
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== START ===");

            //keepWatchingPhotos("silver6wings", 5);
            //fetchStatus("银翎六翼");

            string str = "盘古分词 简介: 盘古分词 是由eaglet 开发的一款基于字典的中英文分词组件" +
                "主要功能: 中英文分词，未登录词识别,多元歧义自动识别,全角字符识别能力" +
                "主要性能指标:" +
                "分词准确度:90%以上" +
                "处理速度: 300-600KBytes/s Core Duo 1.8GHz" +
                "用于测试的句子:" +
                "长春市长春节致词" +
                "长春市长春药店" +
                "IＢM的技术和服务都不错" +
                "张三在一月份工作会议上说的确实在理" +
                "于北京时间5月10日举行运动会" +
                "我的和服务必在明天做好转发微博";

            foreach(string s in WordDivider.panguDivide(str)){
                Console.Write(s + "\t");
            }

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
            List<Status> ls = cr.getUserStatusByUserName(userName, 20, 1);

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