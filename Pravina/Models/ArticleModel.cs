using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pravina.Models
{
    public class ArticleModel
    {
        public string Title;
        public string Link;
        public string Description;
        public string Date;
        public string Africa;
        public string Americas;
        public string AsiaPacific;
        public string Europe;
        public string MiddleEast;
        public string Travel;


        public ArticleModel(string title, string link, string description, string date, string africa, string americas, string asiaPacific, string europe, string middleEast, string travel)
        {
            Title = title;
            Link = link;
            Description = description;
            Date = date;
            Africa = africa;
            Americas = americas;
            AsiaPacific = asiaPacific;
            Europe = europe;
            MiddleEast = middleEast;
            Travel = travel;

        }
    }
}