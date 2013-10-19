using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Silver6wings.WeiboTools
{
    public class SimpleCode
    {
        public static void Main()
        {
            Recorder r = new Recorder(false);
            r.ReadStream("../_Data/Labeling/Result_Database.txt");

            Labeling l = (Labeling)r.ReadNextObject();

            while(l != null){
                Console.WriteLine(l.Category);
                l = (Labeling)r.ReadNextObject();
            }

            r.CloseStream();

            /*
            Crawler crawler = new Crawler();
            crawler.unfollowUserByUserList("../Data/UserList.txt");
            */

            Console.WriteLine("END");
            Console.ReadKey();
        }
    }
}