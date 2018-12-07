using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using NPinyin;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using Microsoft.Win32;
using System.Diagnostics;

namespace TextToSpeechConverter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


namespace ConsoleApp1
    {
        class Program
        {
            /**static void Main(string[] args)
            {
                //Program.getFromReg();
                Program.getWeather();
                Console.ReadKey();

            }*/
            public static void getWeather()
            {
                var Thecity = "北京";
                var city = NPinyin.Pinyin.GetPinyin(Thecity).Replace(" ", "");
                Console.WriteLine(city);
                var url = "http://www.tianqi.com/" + city + '/';
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var weather = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"weather\")]/span/b/text()").InnerText;
                var temperature = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"weather\")]/span/text()").InnerText;
                var present_temp = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"now\")]/b/text()").InnerText + "℃";
                var shidu = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"shidu\")]/b/text()").InnerText;
                var wind = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"shidu\")]/b[2]/text()").InnerText;
                var airquality = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"kongqi\")]/h5/text()").InnerText;
                var pm25 = doc.DocumentNode.SelectSingleNode("//*[contains(@class,\"kongqi\")]/h6/text()").InnerText;
                Console.WriteLine(Thecity + "今日天气:\n\t" + weather);
                Console.WriteLine(Thecity + "今日温度:\n\t" + temperature);
                Console.WriteLine("当前\n\t" + present_temp);
                Console.WriteLine("湿度:\n\t" + shidu);
                Console.WriteLine("风向:\n\t" + wind);
                Console.WriteLine("空气质量:\n\t" + airquality);
                Console.WriteLine("PM 2.5:\n\t" + pm25);
            }


            public static void getFromReg()
            {
                RegistryKey subrk;
                Object objresult;
                string softwarepath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\";
                Console.WriteLine("input name:");
                string softwarename = Console.ReadLine();
                RegistryKey rk = Registry.LocalMachine;
                try
                {
                    subrk = rk.OpenSubKey(softwarepath + softwarename + ".exe");
                    objresult = subrk.GetValue(@"");
                    Process.Start(objresult.ToString());   //Start process without wait
                    Console.Write(objresult.ToString());
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Cannot find this App");
                }
            }

        }
    }
}

/**********************试运行的TensorFlowSharp代码***********************/
/*using (var session = new TFSession())
            {
                Program.getWeather();

            }
            Console.ReadKey();
var graph = session.Graph;
Console.WriteLine(TFCore.Version);
var a = graph.Const(2);
var b = graph.Const(3);
Console.WriteLine("a=2 b=3");

// 两常量加
var addingResults = session.GetRunner().Run(graph.Add(a, b));
var addingResultValue = addingResults.GetValue();
Console.WriteLine("a+b={0}", addingResultValue);

// 两常量乘
var multiplyResults = session.GetRunner().Run(graph.Mul(a, b));
var multiplyResultValue = multiplyResults.GetValue();
Console.WriteLine("a*b={0}", multiplyResultValue);*/


/**************************C#爬虫代码**************************/
/*var weather_string = @"<dd.+?><span><b>(?<content>.+?)</span></b></dd>";
            var temperature_string = "<dd class=\"weather\">(.*?)</dd>";//?<content>.+?
            var request = HttpWebRequest.Create(url);
            string htmlstr;
            var response = (HttpWebResponse)request.GetResponse();
            var response_stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(response_stream, Encoding.UTF8))
            {
                htmlstr = reader.ReadToEnd();
            }
            response_stream.Close();
            response.Close();
            var weather = Regex.Matches(htmlstr, temperature_string, RegexOptions.Multiline);
            foreach (Match match in weather)
            {
                Console.WriteLine(match.Value);
            }
            return weather;*/
/**/
