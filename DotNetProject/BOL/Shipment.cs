using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string BuildingName { get; set; }
        public string Area { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public int Pincode { get; set; }
        
    }
}
