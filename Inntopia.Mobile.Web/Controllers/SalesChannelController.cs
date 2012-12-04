using Inntopia.Mobile.Data;
using Inntopia.Mobile.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inntopia.Mobile.Web.Controllers
{
    public class SalesChannelController : ApiController
    {
        public SearchResponse GetSearch(string id)
        {
            InntopiaClient client = new InntopiaClient(InntopiaServer.Development, InntopiaApplication.IBE);
            return client.GetData<SearchResponse>(
                   new Dictionary<string, object>{
                            { "salesid", id },
                            { "sessionid", new Guid() }, 
                            { "returnxml", 1 }
                        });
        }

        public SearchResponse GetSearch(string id, int superCategoryID, int categoryID, DateTime arrival, DateTime departue)
        {
            InntopiaClient client = new InntopiaClient(InntopiaServer.Development, InntopiaApplication.IBE);
            return client.GetData<SearchResponse>(
                   new Dictionary<string, object>{
                            { "salesid", id },
                            { "sessionid", new Guid() }, 
                            { "productsupercategoryid", superCategoryID }, // more search data data
                            //{ "arrivaldate", arrival.to },
                            //{ "departuredate", departure },
                            { "returnxml", 1 }
                        });
        }
    }
}
