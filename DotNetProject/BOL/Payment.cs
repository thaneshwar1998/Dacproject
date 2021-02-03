using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Payment
    {
       
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public int CVV { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        
    }
}
