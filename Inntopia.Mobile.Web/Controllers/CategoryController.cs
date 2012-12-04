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
    public class CategoryController : ApiController
    {
        public IEnumerable<SuperCategory> GetSuperCategories()
        {
            return null;
        }

        public IEnumerable<Category> GetCategories()
        {
            return null;
        }

    }
}
