using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeiboCrawler
{
    public class Test
    {
        public static void Main()
        {

            Crawler cr = new Crawler();
            while(true)
            {
                Console.WriteLine("Calling...");
                List<Status> ls = cr.getUserStatusByUserName("莉莉努力去哈佛宾大包养小白脸", 10);
                foreach (Status s in ls) Downloader.getStatusPictures(s);
                Thread.Sleep(10000);
            }

            /*
            Recorder rr = new Recorder(false);

            rr.ReadStream("data.txt");
            User ur2 = (User)rr.readObj();

            Console.WriteLine(ur2.Name);

            User ur3 = (User)rr.readObj();
            Console.WriteLine(ur3.Name);
            rr.DropStream();
            */

            /*
            Console.WriteLine("=== END ===");
            Console.ReadKey();
            */
        }
    }
}
