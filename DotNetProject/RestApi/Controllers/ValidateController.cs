using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using BOL;
using DAL;
namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    public class ValidateController : ApiController
    {
        // GET: api/User
        // 
        /*public IEnumerable<User> Get(string email,string password)
        {
            return ValidateManager.ValidateUser(email, password);
        }
        */
        // GET: api/User/5
       /*
        public User Get(string email,string password)
        {
            return ValidateDBManager.validateUser(email, password);

           
        }*/
        // POST: api/User
        public bool Post([FromBody] User theUser)
        {

            return ValidateManager.ValidateUser(theUser);
        }
       
       
        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
