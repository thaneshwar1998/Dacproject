using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
namespace BLL
{
    public class ValidateManager
    {
        
        /*public static List<User> ValidateUser(string email, string password)
        {
            List<User> theUser = new List<User>();
            theUser = ValidateDBManager.validateUser(email, password);
            return theUser;
        }*/

        public static bool ValidateUser(User theUser)
        {
            return ValidateDBManager.validateUser(theUser);
        }
    }
}
