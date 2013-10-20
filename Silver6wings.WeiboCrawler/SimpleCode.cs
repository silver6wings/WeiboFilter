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
            testSerializer("../_Data/Result_Database1.txt");

            Console.WriteLine("END");
            Console.ReadKey();
        }

        static void testSerializer(string filePath){            
            Serializer r = new Serializer(false);
            r.ReadStream(filePath);

            Labeling l = (Labeling)r.ReadNextObject();

            while(l != null){
                Console.WriteLine(l.StatusID + " " + l.Category);
                l = (Labeling)r.ReadNextObject();
            }

            r.CloseStream();
        }
    }
}