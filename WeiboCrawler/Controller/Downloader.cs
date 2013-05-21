using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

namespace WeiboTools
{
    class Downloader
    {
        public static void getPicture(string picURL, string picPath)
        {       
            if (!string.IsNullOrEmpty(picURL))
            {
                try
                {
                    WebClient wb = new WebClient();
                    wb.DownloadFile(picURL, picPath);
                    Console.WriteLine("Downloading..." + picPath);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("{0}", ex.GetType().Name);
                    Console.WriteLine("{0}", ex.StackTrace);
                }
            }        
        }

        public static void getStatusPictures(Status status)
        {
            string s = null;
            if (status != null)
            {
                s = status.OriginalPictureUrl;
                if (!string.IsNullOrEmpty(s))
                {
                    string[] ss = s.Split('/');
                    string picPath = Properties.Crawler.Default.picPath + "o_" + ss[ss.Length - 1];
                    if (!File.Exists(picPath))
                    {
                        Downloader.getPicture(s, picPath);
                    }
                }

                s = status.MiddleSizePictureUrl;
                if (!string.IsNullOrEmpty(s))
                {
                    string[] ss = s.Split('/');
                    string picPath = Properties.Crawler.Default.picPath + "m_" + ss[ss.Length - 1];

                    if (!File.Exists(picPath))
                    {
                        Downloader.getPicture(s, picPath);
                    }
                }
            }
        }
    }
}
