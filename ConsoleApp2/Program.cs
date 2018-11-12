using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
//using Jayrock.Json;
//using Jayrock.Json.Conversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args){
            
            string M_str_sqlcon = "server=localhost;user id=root;password=;database=guessing_league"; //根据自己的设置
            MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
            myCon.Open();
            MySqlDataAdapter mysda = new MySqlDataAdapter();
            mysda.SelectCommand = new MySqlCommand();
            mysda.SelectCommand.Connection = myCon;
            mysda.SelectCommand.CommandText = "select * from user_list";

            mysda.SelectCommand.ExecuteNonQuery();

            DataSet ds = new DataSet();
            //Console.WriteLine(ds.Tables[0].Rows[0].ToString());

            //GridView1.DataSource = ds;
            //GridView1.DataBind();

            mysda.Fill(ds);
            myCon.Close();

            foreach (DataRow i in ds.Tables[0].Rows) {
                //Console.WriteLine(i[1].ToString());
                foreach (var j in i.ItemArray){
                    Console.WriteLine(j.ToString());
                }
            }


            Console.ReadKey();
            return;
            string jsonText = HttpGet("http://op.juhe.cn/onebox/football/team?dtype=&team=%E6%9B%BC%E8%81%94&key=c44c8cab0848d9e5fcc35809e45be3ec");
            
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);
            
            string reason   = jo["reason"].ToString();
            string key      = jo["result"]["key"].ToString();
            string list = jo["result"]["list"].ToString();
            JArray jArray = (JArray)JsonConvert.DeserializeObject(list);//jsonArrayText必须是带[]数组格式字符串
            
            
            foreach (var i in jo) {
                //Console.WriteLine(i.ToString());
            }

            foreach (var i in jArray) {
                Console.WriteLine(i["c1"]);
            }


            // Console.WriteLine(jArray[0]["c1"]);


            //string list     = jo["reason"]["key"]["list"].ToString();
            //string result = jo["result"]["c1"].ToString();

            //JArray jArray = (JArray)JsonConvert.DeserializeObject(jsonText);//jsonArrayText必须是带[]数组格式字符串





            //User user = (User)Jayrock.Json.Conversion.JsonConvert.Import(typeof(User), ss);
            //var mJObj = JArray.Parse(ss);
            //foreach (var i in mJObj) {
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(jsonText);
            //Console.WriteLine(reason);
            //Console.WriteLine(key);
            //Console.WriteLine(list);

            //Console.WriteLine(key);
            //Console.WriteLine(list);
            //Console.WriteLine(result);
            //Console.WriteLine(jArray['result']);
            //Console.WriteLine(zone);
            //Console.WriteLine(result);
            //Console.WriteLine(user);
            //Console.WriteLine(user.reason);

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

    public class User {
        public User() {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private int id;

        public string reason;
        public string[] result;

        //public string c4r;
        //public string result;
        //User result;

        public int Id {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }
        private DateTime time;

        public DateTime Time {
            get { return time; }
            set { time = value; }
        }
        private double money;

        public double Money {
            get { return money; }
            set { money = value; }
        }
        private string[] str;

        public string[] Str {
            get { return str; }
            set { str = value; }
        }
    }
}
