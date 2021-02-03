using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using BOL;
namespace DAL
{
    public static class ValidateDBManager
    {
        public static readonly string connString = string.Empty;
        static ValidateDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;

        }
        //public static List<User> validateUser(string LoginName, string Password)
        //{
        //     bool status = false;
        //    List<User> theUser = new List<User>();
        //    IDbConnection con = new MySqlConnection(connString);
        //    //SQL DB Injection Problem
        //    string query = "SELECT * FROM Customers WHERE Email= @username AND Password =@password";
        //    IDbCommand cmd = new MySqlCommand(query);
        //    cmd.Parameters.Add(new MySqlParameter("username", LoginName));
        //    cmd.Parameters.Add(new MySqlParameter("password", Password));
        //    cmd.Connection = con;
        //    try
        //    {
                
                
        //        con.Open();
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            status = true;
        //        }
        //        reader.Close();
        //        con.Close();
        //    }
        //    catch (MySqlException)
        //    {
        //    }
        //    return theUser;



        //}
       public static bool validateUser(User theUser)
        {
            bool status = false;
            IDbConnection con = new MySqlConnection(connString);
            string query = "SELECT * FROM Customers WHERE Email= @email AND Password =@password";
            IDbCommand cmd = new MySqlCommand(query);
            cmd.Parameters.Add(new MySqlParameter("email", theUser.Email));
            cmd.Parameters.Add(new MySqlParameter("password", theUser.Password));
            cmd.Connection = con;
            try
             {
                  con.Open();
                  IDataReader reader = cmd.ExecuteReader();
                   if (reader.Read())
                   {
                       status = true;
                   }
                        reader.Close();
                        con.Close();
                }
            catch (MySqlException ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return status;

        }
       /* public static User validateUser(string email,string password)
        {
            bool status = false;
            IDbConnection con = new MySqlConnection(connString);
            string query = "SELECT * FROM Customers WHERE Email= @email AND Password =@password";
            IDbCommand cmd = new MySqlCommand(query);
            cmd.Parameters.Add(new MySqlParameter("email", email));
            cmd.Parameters.Add(new MySqlParameter("password", password));
            cmd.Connection = con;
            try
            {
                con.Open();
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    status = true;
                }
                reader.Close();
                con.Close();
            }
            catch (MySqlException ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return null;

        }*/
    }
}
