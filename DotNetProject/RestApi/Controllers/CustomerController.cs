using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BOL;
using BLL;
namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            return CustomerManager.GetAllCustomers();
        }

        // GET: api/Customer/5
        public bool Get(string email,string password)
        {
            return CustomerManager.GetCustomer(email,password);
        }

        // POST: api/Customer
        public bool Post([FromBody] Customer value)
        {
            return CustomerManager.InsertCustomer(value);
        }
       
        // PUT: api/Customer/5
        public Customer Put(int id, [FromBody] Customer theCustomer)
        {
            return CustomerManager.UpdateCustomer(id,theCustomer);
        }

        // DELETE: api/Customer/5
        public bool Delete(int id)
        {
            return CustomerManager.DeleteCustomer(id);
        }
    }
}
