using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Pravina
{
    class Parser
    {

       

        public List<List<KeyValuePair<string, string>>> ParseRssFile(string region)
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            //Load the RSS file from the RSS URL
            string formattedRssURL = String.Format("http://rss.nytimes.com/services/xml/rss/nyt/{0}.xml", region);
            rssXmlDoc.Load(formattedRssURL);

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            List<List<KeyValuePair<string, string>>> rssContent = new List<List<KeyValuePair<string, string>>> ();

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                List<KeyValuePair<string, string>> article = new List<KeyValuePair<string, string>>();

                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";
                article.Add(new KeyValuePair<string, string>("title", title));

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";
                article.Add(new KeyValuePair<string, string>("link", link));

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";
                article.Add(new KeyValuePair<string, string>("description", description));

                rssContent.Add(article);
            }

            // Return the list that contain the RSS items
            return rssContent;

        }
    }
}
