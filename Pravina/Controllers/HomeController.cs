using Newtonsoft.Json;
using Pravina.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;

namespace Pravina.Controllers
{
    public class HomeController : Controller
    {

        
  
        public ActionResult Index()
        {

            // Create a parser and use it to get the articles from the RSS feeds
            Parser parser = new Parser();

            List<List<KeyValuePair<string, string>>> parsedRSS = parser.ParseRssFile("MiddleEast");

            // get number of articles and use it to generate random number to select an article at random
            int numberOfArticles = parsedRSS.Count;
            Random r = new Random();
            int articleIndex = r.Next(0, numberOfArticles - 1);
            List<KeyValuePair<string, string>> article = parsedRSS[articleIndex];

            // get the values for the model
            string title = article[0].Value != null ? article[0].Value : "";
            string link = article[1].Value != null ? article[1].Value : "";
            string description = article[2].Value != null ? article[2].Value : "";

            //populate model
            ArticleModel model = new ArticleModel(title, link, description, "", "", "", "", "", "", "");

            if (Request.RequestType == "POST") { 

                return Content(JsonConvert.SerializeObject(model));
            
            }

            return View(model);

        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your login description page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your registration page.";

            return View();
        }

        public void Update()
        {

        }
    }
}