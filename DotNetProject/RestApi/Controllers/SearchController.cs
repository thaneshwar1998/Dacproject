using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using BOL;
namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {
        [AllowAnonymous]
        // GET: api/Search
        /* public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }*/

        
        public Books Get(string category)
        {
            return SearchManager.GetBooksByCategory(category);
        }

        // POST: api/Search
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
    }
}
