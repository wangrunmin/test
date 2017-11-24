using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args[0] != null)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(args[0]);
                    request.Method = "GET";
                    request.ContentType = "text/html;charset=UTF-8";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                    File.AppendAllLines(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Time的日志.txt"), new string[] { retString });
                }
                else
                {
                    throw new Exception("执行失败，没有指定接口的地址。");
                }
            }
            catch (Exception e)
            {
                File.AppendAllLines(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Time的日志.txt"), new string[] { e.Message });
            }
        }
    }
}
