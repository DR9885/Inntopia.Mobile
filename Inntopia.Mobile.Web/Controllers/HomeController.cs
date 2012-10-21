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
//            HttpContext.Cache.
            if (HttpContext.Cache["SupplierDetails" + id] == null)
            {
                var supplierDetials = Data<SupplierDetails>("http://dev.inntopia.com/aspnet/09/supplier.aspx?supplierid=" + id + "&advancedsearch=1&returnxml=1");
                HttpContext.Cache.Add("SupplierDetails" + id, supplierDetials, null, DateTime.Now.AddHours(2), TimeSpan.Zero, CacheItemPriority.High, null);
            }

            return View(HttpContext.Cache["SupplierDetails" + id]);
        }


        public ActionResult Selector(int id)
        {
            var selector = Data<Selector>("http://www.inntopia.travel/aspnet/09/selector.aspx?salesid=" + id + "&advancedsearch=1&returnxml=1");
     
            return View(selector);
        }
    }
}
