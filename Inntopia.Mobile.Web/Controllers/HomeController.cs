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
        public InntopiaClient InntopiaClient { get; set; }

        public HomeController()
        {
            InntopiaClient = new InntopiaClient(InntopiaServer.Development, InntopiaApplication.IBE);
        }

        [OutputCache(Duration = 86400, VaryByParam = "id")]
        public ActionResult Index()
        {
            InntopiaClient client = new InntopiaClient();

            var model = InntopiaClient.GetData<InntopiaStart>(
                    InntopiaRequest.Start, new Dictionary<string, object> { 
                        { "salesid", 80000 }, 
                        { "returnxml", 1 }
                    });

            return View(model);
        }

        [OutputCache(Duration = 86400, VaryByParam = "id")]
        public ActionResult Supplier(int id = 80000)
        {
            var model = InntopiaClient.GetData<SupplierDetails>(InntopiaRequest.Supplier,
                        new Dictionary<string, object> {
                            { "supplierid", id },
                            { "advancedsearch", 1 }, // more search data data
                            { "returnxml", 1 }
                        });

            return View(model);
        }


        [OutputCache(Duration = 86400, VaryByParam = "id")]
        public ActionResult Start(int id = 80000)
        {
            var model = InntopiaClient.GetData<Selector>(InntopiaRequest.Selector,
                        new Dictionary<string, object>{
                            { "salesid", id },
                            { "advancedsearch", 1 }, // more search data data
                            { "returnxml", 1 }
                        });

            return View(model);
        }

        [OutputCache(Duration = 86400,
            VaryByParam = "id;productSuperCategoryID;productCategoryID;arrival;departure")]
        public ActionResult Search(int id, int productSuperCategoryID, string arrival, string departure, string sessionID = null)
        {
            var model = InntopiaClient.GetData<SearchResults>(InntopiaRequest.Search,
                   new Dictionary<string, object>{
                            { "salesid", id },
                            { "sessionid", new Guid() }, 
                            { "productsupercategoryid", productSuperCategoryID }, // more search data data
                            { "arrivaldate", arrival },
                            { "departuredate", departure },
                            { "returnxml", 1 }
                        });

            return View(model);
        }
    }
}
