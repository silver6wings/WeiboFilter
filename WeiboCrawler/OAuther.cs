using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetDimension.Weibo;

namespace WeiboCrawler
{
    class OAuther
    {
        static string AppKey = Properties.WeiboOAuth.Default.AppKey;
        static string AppSecret = Properties.WeiboOAuth.Default.AppSecrect;

        private static bool ClientLogin(OAuth o)
        {
            string passport = Properties.WeiboOAuth.Default.WeiboUser;
            string password = Properties.WeiboOAuth.Default.WeiboPassword;

            return o.ClientLogin(passport, password);
        }

        static OAuth Authorize()
        {
            OAuth o = new OAuth(
                Properties.WeiboOAuth.Default.AppKey, 
                Properties.WeiboOAuth.Default.AppSecrect, 
                Properties.WeiboOAuth.Default.CallbackUrl
                );

            //让使用者自行选择一个授权方式
            Console.WriteLine("Please choose OAuth mode:");
            Console.WriteLine("1.Standard process");
            Console.WriteLine("2.Second process");//一键授权登录


            //ConsoleKeyInfo key = Console.ReadKey(true);
            Console.WriteLine("Auto use second one ....");
            /*
            if (key.Key == ConsoleKey.D2)	//使用模拟方法
            */

            //这里使用第二种方法抓取
            {
                while (!ClientLogin(o))
                {
                    Console.WriteLine("OAuth fail, please try again.");
                    Console.WriteLine("");
                }
                Console.WriteLine("OAuth success!");
            }
            /*
            else
            {
                string authorizeUrl = o.GetAuthorizeURL();
                System.Diagnostics.Process.Start(authorizeUrl);
                Console.Write("复制浏览器中的Code:");
                string code = Console.ReadLine();
                try
                {
                    AccessToken accessToken = o.GetAccessTokenByAuthorizationCode(code); //请注意这里返回的是AccessToken对象，不是string
                }
                catch (WeiboException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            */

            return o;
        }

        public static Client getOAuth()
        {
            OAuth oauth = null;

            Properties.WeiboOAuth.Default.AccessToken = string.Empty;
            Properties.WeiboOAuth.Default.Save();

            string accessToken = Properties.WeiboOAuth.Default.AccessToken;
            if (string.IsNullOrEmpty(accessToken))	//判断配置文件中有没有保存到AccessToken，如果没有就进入授权流程
            {
                oauth = Authorize();

                if (!string.IsNullOrEmpty(oauth.AccessToken))
                {
                    Console.WriteLine("Get AccessToken{{{0}}} success!", oauth.AccessToken);
                    Console.Write("Save Token to local in order to launch automaticaly next time? [Y/N]: Y");
                    /*
                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                     * */
                    {
                        Properties.WeiboOAuth.Default.AccessToken = oauth.AccessToken;
                        Properties.WeiboOAuth.Default.Save();
                        //配置文件已保存。如果要撤销AccessToken请删除ConsoleApp.exe.config中AcceessToken节点中的Token值。
                        Console.WriteLine();
                        Console.WriteLine("Token Saved.");
                    }
                    /*
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("AccessToken unsaved.");
                    }
                    */
                }
            }
            else //如果配置文件中保存了AccesssToken
            {
                Console.WriteLine("Get saved AccessToken{{{0}}}!", accessToken);
                oauth = new OAuth(AppKey, AppSecret, accessToken, "");	//用Token实例化OAuth无需再次进入验证流程
                Console.Write("Checking the saved Token ... ");
                TokenResult result = oauth.VerifierAccessToken();	//测试保存的AccessToken的有效性
                if (result == TokenResult.Success)
                {
                    Console.WriteLine("Done!");

                    /*
                    Console.Write("Delete the saved token in order to OAuth next time？[Y/N]:");
                    if (Console.ReadKey(true).Key == ConsoleKey.Y)
                    {
                        //如果想演示下登录授权，那就得把配置文件中的Token删除，所以做那么一个判断。
                        Properties.WeiboOAuth.Default.AccessToken = string.Empty;
                        Properties.WeiboOAuth.Default.Save();
                        //已从配置文件移除AccessToken值，重新运行程序来演示授权过程。
                        Console.WriteLine();
                        Console.WriteLine("Access Token Removed");
                    }
                    // */
                }
                else
                {
                    Console.WriteLine("Error! Message:{0}", result);
                    Properties.WeiboOAuth.Default.AccessToken = string.Empty;
                    Properties.WeiboOAuth.Default.Save();
                    //已从配置文件移除AccessToken值，重新运行程序获取有效的AccessToken
                    Console.WriteLine("Access Token Deleted, Please run again.");
                    Console.ReadKey();
                    return null; //AccessToken无效，继续执行没有任何意义，反正也无法调用API
                }
            }

            //好吧，授权至此应该成功了。下一步调用接口吧。
            return new Client(oauth);
        }

    }
}
