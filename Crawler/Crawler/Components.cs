using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class Components
    {
        public string GetProductName (string html)
        {
            // You should check for errors in real-world code, omitted for brevity
            var startTag = "<span class=\"text14red\">";
            int startIndex = html.IndexOf(startTag) + startTag.Length;
            int endIndex = html.IndexOf("</span>", startIndex);
            return html.Substring(startIndex, endIndex - startIndex);
           // return null;
        }
    }
}
