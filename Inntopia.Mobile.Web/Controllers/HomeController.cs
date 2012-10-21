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
        public InntopiaStart InntopiaCache
        {
            get
            {
                if (HttpContext.Cache["inntopia"] == null)
                {
                    // Create a request using a URL that can receive a post. 
                    WebRequest request = WebRequest.Create("http://dev.inntopia.com/aspnet/09/start.aspx?salesid=80000&returnxml=1");
                    request.Method = "GET";
                    request.ContentType = "application/xml";
                    WebResponse response = request.GetResponse();

                    // Serialize the object
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(InntopiaStart));
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    var inntopiaStart = xmlSerializer.Deserialize(reader) as InntopiaStart;
                    reader.Close();

                    HttpContext.Cache.Add("inntopia", inntopiaStart, null, DateTime.Now.AddHours(2), TimeSpan.Zero, CacheItemPriority.High, null);

                }
                return HttpContext.Cache["inntopia"] as InntopiaStart;
            }
        }

        public SupplierDetails SupplierDetails
        {
            get
            {
                if (HttpContext.Cache["SupplierDetails"] == null)
                {
                    // Create a request using a URL that can receive a post. 
                    WebRequest request = WebRequest.Create("http://dev.inntopia.com/aspnet/09/start.aspx?salesid=80000&returnxml=1");
                    request.Method = "GET";
                    request.ContentType = "application/xml";
                    WebResponse response = request.GetResponse();

                    // Serialize the object
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(InntopiaStart));
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    var inntopiaStart = xmlSerializer.Deserialize(reader) as InntopiaStart;
                    reader.Close();

                    HttpContext.Cache.Add("SupplierDetails", inntopiaStart, null, DateTime.Now.AddHours(2), TimeSpan.Zero, CacheItemPriority.High, null);

                }
                return HttpContext.Cache["SupplierDetails"] as SupplierDetails;
            }
        }

        public ActionResult Index()
        {
            
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(InntopiaCache);
        }

        public ActionResult Supplier()
        {



            return View(SupplierDetails);
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
