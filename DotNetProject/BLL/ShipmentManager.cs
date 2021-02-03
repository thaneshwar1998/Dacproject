using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
namespace BLL
{
    public class ShipmentManager
    {
        public static Shipment NewShipment(Shipment newShipment)
        {
            return ShipmentDBManager.newShipment(newShipment);
        }
    }
}
