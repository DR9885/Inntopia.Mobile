using System.Collections.Generic;
using System.Web.Http;

namespace Inntopia.BookingEngine.Mobile.Web.Controllers
{
    public class SelectorController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post(string value)
        {
            int i = 0;
            return value;
        }

        // PUT api/<controller>/5
        public string Put(int id, string value)
        {
            int i = 0;
            return value;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}