using Inntopia.Mobile.Data;
using Inntopia.Mobile.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Inntopia.Mobile.Web.Controllers
{
    public class HomeController : Controller
    {
        public enum Server
        {
            Development,
            Stage,
            Production
        }

        public Server _Server = Server.Development;

        public InntopiaStart InntopiaCache
        {
            get
            {
                if (HttpContext.Cache["inntopia"] == null)
                    HttpContext.Cache.Add("inntopia", 
                        Data<InntopiaStart>("http://dev.inntopia.com/aspnet/09/start.aspx?salesid=80000&returnxml=1"), 
                        null, DateTime.Now.AddHours(2), TimeSpan.Zero, CacheItemPriority.High, null);
                return HttpContext.Cache["inntopia"] as InntopiaStart;
            }
        }

        public string Domain
        {
            get
            {
                string domain = "";
                switch (_Server)
                {
                    case Server.Development: domain = "https://dev.inntopia.com/"; break;
                    case Server.Stage: domain = "https://stage.inntopia.net/"; break;
                    case Server.Production: domain = "https://www.inntopia.travel/"; break;
                    default: break;
                }
                return domain;
            }
        }

        public string GetURL(Server server, string page, Dictionary<string,object> parameters)
        {
            string url = "";
            switch (_Server)
            {
                case Server.Development: url = "http://dev.inntopia.com/"; break;
                case Server.Stage: url = "https://stage.inntopia.net/"; break;
                case Server.Production: url = "https://www.inntopia.travel/"; break;
                default: break;
            }

            page = page.ToLower();
            switch (page.ToLower())
            {
                case "start":
                case "selector":
                case "search":
                case "supplier":
                    url += "aspnet/09/" + page + ".aspx"; break;
                default: break;
            }

            return url + "?" + String.Join("&", parameters.Select(x => x.Key + "=" + x.Value));
        }

        public T Data<T>(string url)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/xml";
            WebResponse response = request.GetResponse();

            // Serialize the object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var obj = xmlSerializer.Deserialize(reader);
            reader.Close();

            return (T)obj;
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(InntopiaCache);
        }

        public ActionResult Supplier(int id)
        {
            var URL = "aspnet/09/supplier.aspx?supplierid=" + id + "&advancedsearch=1&returnxml=1";

            if (HttpContext.Cache[URL] == null)
                HttpContext.Cache.Add(URL, Data<SupplierDetails>(GetURL(Server.Development, "Supplier",
                        new Dictionary<string, object>()
                        {
                            { "supplierid", id },
                            { "returnxml", 1 }
                        })),
                    null, DateTime.Now.AddHours(12), TimeSpan.Zero, CacheItemPriority.High, null);

            return View(HttpContext.Cache[URL]);
        }


        public ActionResult Selector(int id)
        {
            var URL = GetURL(Server.Development, "Selector",
                        new Dictionary<string, object>()
                        {
                            { "salesid", id },
                            { "advancedsearch", 1 },
                            { "returnxml", 1 }
                        });

            if (HttpContext.Cache[URL] == null)
                HttpContext.Cache.Add(URL, Data<Selector>(URL),
                    null, DateTime.Now.AddHours(12), TimeSpan.Zero, CacheItemPriority.High, null);

            return View(HttpContext.Cache[URL]);
        }

        public ActionResult Search(int salesID, int productSuperCategoryID, string arrival, string departure, string sessionID = null)
        {
            Session["SalesID"] = salesID;

            var URL = Domain + "aspnet/09/search.aspx" +
                "?salesid=" + salesID +
                "&productsupercategoryid=" + productSuperCategoryID +
                "&arrivaldate=" + arrival +
                "&departuredate=" + departure;

            if (HttpContext.Cache[URL] == null)
                HttpContext.Cache.Add(URL, Data<SearchResults>(URL + "&sessionID=" + Session.SessionID + "&returnxml=1"),
                   null, DateTime.Now.AddHours(2), TimeSpan.Zero, CacheItemPriority.High, null);

            return View(HttpContext.Cache[URL]);
        }
    }
}
