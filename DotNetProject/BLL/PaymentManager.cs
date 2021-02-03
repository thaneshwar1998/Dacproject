using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
namespace BLL
{
    public class PaymentManager
    {
        public static Payment NewPayment(Payment newPayment)
        {
            return PaymentDBManager.NewPayment(newPayment);
        }
    }
}
