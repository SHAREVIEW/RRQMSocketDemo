using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RPCHttpClient
{
    class Program
    {
        static string Url = "http://127.0.0.1:7789/";
        static void Main(string[] args)
        {
            HttpGet();
            
            Console.ReadKey();
        }

        public static string HttpPost()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            Encoding encoding = Encoding.UTF8;
            byte[] postData = encoding.GetBytes("data");
            request.ContentLength = postData.Length;
            Stream myRequestStream = request.GetRequestStream();

            myRequestStream.Write(postData, 0, postData.Length);
            myRequestStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, encoding);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        //GET方法
        public static string HttpGet()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=utf-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
           int a= retString.Length;
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
    }
}
