using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;



namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args){



            return;
            string ss = HttpGet("http://op.juhe.cn/onebox/football/team?dtype=&team=%E6%9B%BC%E8%81%94&key=c44c8cab0848d9e5fcc35809e45be3ec");
            Console.WriteLine(ss);
            Console.ReadKey();
        }

        public static string HttpGet(string url)
        {
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }


}
