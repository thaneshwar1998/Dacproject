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
    public class OrdersController : ApiController
    {
        // GET: api/Orders
        public IEnumerable<OrderDetails> Get()
        {
            return OrderManager.GetAllOrders();
        }

        // GET: api/Orders/5
        public OrderDetails Get(int id)
        {
            return OrderManager.GetOrderDetailsById(id);
        }

        
        // POST: api/Orders
        public OrderDetails Post([FromBody]OrderDetails newOrder)
        {
            return OrderManager.InsertOrders(newOrder);
        }

        // PUT: api/Orders/5
        public void Put(int id, [FromBody]OrderDetails value)
        {
            OrderManager.UpdateOrderDetails(value);
        }

        // DELETE: api/Orders/5
        public bool Delete(int id)
        {
            return OrderManager.DeleteOrdersById(id);
        }
    }
}
