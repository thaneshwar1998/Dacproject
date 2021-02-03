using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        
        public double Price { get; set; }
        public string OrderName { get; set; }
        public double TotalAmount { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        
    }
}
