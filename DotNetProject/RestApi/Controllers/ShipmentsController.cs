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
    public class ShipmentsController : ApiController
    {
        // GET: api/Shipments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Shipments/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shipments
        public Shipment Post([FromBody]Shipment newShipment)
        {
            return ShipmentManager.NewShipment(newShipment);
        }

        // PUT: api/Shipments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shipments/5
        public void Delete(int id)
        {
        }
    }
}
