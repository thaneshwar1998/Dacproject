using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using BOL;
namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaymentsController : ApiController
    {
        // GET: api/Payments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Payments/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Payments
        public Payment Post([FromBody]Payment newPayment)
        {
            return PaymentManager.NewPayment(newPayment);
        }

        // PUT: api/Payments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Payments/5
        public void Delete(int id)
        {
        }
    }
}
