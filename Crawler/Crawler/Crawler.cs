using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Crawler;

namespace Crawler
{
    public static class Crawler
    {
        static void Main(string[] args)
        {
            var test = GetWebText("");
            Console.WriteLine(test);
            Components components = new Components();
            Console.WriteLine(components.GetProductName(test).Trim());
            //var auth = Authentication();
            //Console.WriteLine(auth.Result);
        }
        private static string GetWebText(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            Cookie auth = new Cookie("PHPSESSID", "8i8md4lhlldbsqtq0im1pn8n60");
            auth.Domain = ""; //TODO add domain 
            auth.Path = "/";
            TryAddCookie(request, auth);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string htmlText = reader.ReadToEnd();
            //var productInfoIndex = htmlText.IndexOf("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" height=\"454\">"); 
            //Console.WriteLine(productInfoIndex);    
            //var output = htmlText.Substring(productInfoIndex);
            //Console.WriteLine(ProductName(output, "span"));
            //return output;
            return htmlText;
        }

       // private async static Task<string> Authentication()
       // {
       //     using (var client = new HttpClient())
       //     {
       //         var values = new Dictionary<string, string>
       //             {
       //                { "122", "12345611" }
       //             };
       //
       //         var content = new FormUrlEncodedContent(values);
       //
       //         var response = await client.PostAsync("", content);
       //         var statusCode = response.StatusCode.GetHashCode();
       //
       //         return statusCode.ToString();
       //         //var responseString = await response.Content.ReadAsStringAsync();
       //     }
       // }

        public static bool TryAddCookie(this WebRequest webRequest, Cookie cookie)
        {
            HttpWebRequest httpRequest = webRequest as HttpWebRequest;
            if (httpRequest == null)
            {
                return false;
            }
        
            if (httpRequest.CookieContainer == null)
            {
                httpRequest.CookieContainer = new CookieContainer();
            }
        
            httpRequest.CookieContainer.Add(cookie);
            return true;
        }
       // public static string ProductName(string s, string tag)
       // {  
       //     // You should check for errors in real-world code, omitted for brevity
       //     var startTag = "<" + tag + "class=\"text14red\">";
       //     int startIndex = s.IndexOf(startTag) + startTag.Length;
       //     int endIndex = s.IndexOf("</" + tag + ">", startIndex);
       //     return s.Substring(startIndex, endIndex - startIndex);
       // }
    }
}
