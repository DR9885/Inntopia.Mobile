using Inntopia.Mobile.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://www.inntopia.travel/aspnet/09/selector.aspx?salesid=80002&advancedsearch=1&returnxml=1");
            request.Method = "GET";
            request.ContentType = "application/xml";
            WebResponse response = request.GetResponse();
            
            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Selector));
            StreamReader reader = new StreamReader(response.GetResponseStream());
            Selector selector = xmlSerializer.Deserialize(reader) as Selector;
            reader.Close();

            
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Selector()
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("http://www.inntopia.travel/aspnet/09/selector.aspx?salesid=80002&advancedsearch=1&returnxml=1");
            request.Method = "GET";
            request.ContentType = "application/xml";
            WebResponse response = request.GetResponse();

            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Selector));
            StreamReader reader = new StreamReader(response.GetResponseStream());
            Selector selector = xmlSerializer.Deserialize(reader) as Selector;
            reader.Close();


            return View(selector);
        }
    }
}
