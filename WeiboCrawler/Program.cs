using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeiboCrawler
{
    public class Test
    {
        public static void Main()
        {            
            Crawler mr = new Crawler();
   
            User ur = mr.getUserInfo("银翎六翼");

            Console.WriteLine(ur.Description);

            /*
            Recorder rr = new Recorder(false);

            rr.ReadStream("data.txt");
            User ur2 = (User)rr.readObj();

            Console.WriteLine(ur2.Name);

            User ur3 = (User)rr.readObj();
            Console.WriteLine(ur3.Name);
            rr.DropStream();
            */

            Console.ReadKey();
        }
    }
}
