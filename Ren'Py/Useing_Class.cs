using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ren_Py
{
    public static class Tools_Class
    {
        public static string MidStrEx(string sourse, string startstr, string endstr)
        {
            string result = string.Empty;
            int startindex, endindex;
            try
            {
                startindex = sourse.IndexOf(startstr);
                if (startindex == -1)
                    return result;
                string tmpstr = sourse.Substring(startindex + startstr.Length);
                endindex = tmpstr.IndexOf(endstr);
                if (endindex == -1)
                    return result;
                result = tmpstr.Remove(endindex);
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        private static string Sign(string Text,string salt)
        {
            return string.Format("{0}{1}{2}{3}", "20181206000244475", Text, salt, "DtifQlWVfd0DbytYN_nu"); 
        }
        private static string GetSign(string Text,string salt)
        {
            var md5 = new MD5CryptoServiceProvider();
            var result = Encoding.UTF8.GetBytes(Sign(Text, salt));
            var output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "").ToLower();
        }
        private static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        public static string Web_Translate(int seletc,string Text)
        {
            try
            {
                string StrText;
                RestClient client;
                RestRequest request;
                string salt = GetTimeStamp();
                switch (seletc)
                {
                    case 1:
                        //有道翻译
                        client = new RestClient("http://fanyi.youdao.com");
                        request = new RestRequest("/translate", Method.GET);
                        request.AddParameter("doctype", "json");
                        request.AddParameter("type", "AUTO");
                        request.AddParameter("i", Text);
                        break;
                    case 2:
                        //百度翻译
                        client = new RestClient("http://api.fanyi.baidu.com");
                        request = new RestRequest("/api/trans/vip/translate", Method.GET);
                        request.AddParameter("q", Text);
                        request.AddParameter("from", "auto");
                        request.AddParameter("to", "zh");
                        request.AddParameter("appid", "20181206000244475");
                        request.AddParameter("salt", salt);
                        request.AddParameter("sign", GetSign(Text, salt));
                        Thread.Sleep(1000);
                        break;
                    case 3:
                        //有道翻译收费
                        string curtime = Youdaocurtime();
                        salt = DateTime.Now.Millisecond.ToString();
                        client = new RestClient("https://openapi.youdao.com");
                        request = new RestRequest("/api", Method.GET);
                        request.AddParameter("q", Text);
                        request.AddParameter("from", "AUTO");
                        request.AddParameter("to", "zh-CHS");
                        request.AddParameter("appKey", "13000a91a8e24fd4");
                        request.AddParameter("salt", salt);
                        request.AddParameter("curtime", curtime);
                        request.AddParameter("sign", YouDaoSign(Text, salt, curtime));
                        request.AddParameter("signType", "v3");
                        break;
                    default:
                        //默认有道翻译
                        client = new RestClient("http://fanyi.youdao.com");
                        request = new RestRequest("/translate", Method.GET);
                        request.AddParameter("doctype", "json");
                        request.AddParameter("type", "AUTO");
                        request.AddParameter("i", Text);
                        break;
                }
                IRestResponse response = client.Execute(request);
                //开始解析JsonerrorCode
                Console.WriteLine(response.Content);
                JObject Tr = (JObject)JsonConvert.DeserializeObject(response.Content);
                if (Tr["trans_result"] != null){
                    StrText = Tr["trans_result"][0]["dst"].ToString();
                }
                else if (Tr["translateResult"] != null){
                    StrText = Tr["translateResult"][0][0]["tgt"].ToString();
                }
                else {
                    StrText = Tr["translation"][0].ToString();
                }
                foreach(var TempList in Main.Config.m_Translation_Corrnt)
                {
                    StrText = StrText.Replace(TempList.Key, TempList.Value);
                }
                return StrText;

            }
            catch (Exception ex)
            {
                return "";
            }
        }
        private static string Youdaocurtime()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            long millis = (long)ts.TotalMilliseconds;
            return Convert.ToString(millis / 1000);
        }
        private static string YouDaoSign(string Text, string salt, string curtime)
        {
           return ComputeHash(string.Format("{0}{1}{2}{3}{4}", "13000a91a8e24fd4", Text.Length <= 20 ? Text : (Text.Substring(0, 10) + Text.Length.ToString() + Text.Substring(Text.Length - 10, 10)) , salt, curtime, "C7UlkpSJxOwUIbf1jG5vXOfyL8Oe6cc1"), new SHA256CryptoServiceProvider());
        }
        private static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}
