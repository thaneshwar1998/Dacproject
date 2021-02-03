using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
   public class CustomerManager
    {
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> allCustomers = new List<Customer>();
            allCustomers = CustomerDBManager.GetAllCustomers();
            return allCustomers;
        }

        public static Customer GetCustomerById(int id)
        {
            return CustomerDBManager.GetCustomerById(id);
        }
        public static bool GetCustomer(string email,string password)
        {
            return CustomerDBManager.GetCustomer(email,password);
        }
        public static bool InsertCustomer(Customer theCustomer)
        {
            return CustomerDBManager.AddNewCustomer(theCustomer);
        }

        
        public static Customer UpdateCustomer(int id,Customer theCustomer)
        {
            return CustomerDBManager.Update(id,theCustomer);
        }
        public static bool DeleteCustomer(int id)
        {
            return CustomerDBManager.Delete(id);
        }
    }
}
