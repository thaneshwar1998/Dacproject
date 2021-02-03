using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class OrderManager
    {
       
        public static List<OrderDetails> GetAllOrders()
        {
            List<OrderDetails> Orders = new List<OrderDetails>();
            Orders = OrderManager.GetAllOrders();
            return Orders;
        }
        public static OrderDetails GetOrderDetailsById(int id)
        {
            return OrdersDBManager.GetOrderById(id);
        }
        public static OrderDetails InsertOrders(OrderDetails theOrder)
        {
            return OrdersDBManager.NewOrder(theOrder);
        }        
        public static bool UpdateOrderDetails(OrderDetails theOrder)
        {
            return OrdersDBManager.Update(theOrder);
        }
        public static bool DeleteOrdersById(int id)
        {
            return OrdersDBManager.Delete(id);
        }
    }
}
