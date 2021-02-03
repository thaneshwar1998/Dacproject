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
    public class CustomerDBManager
    {
        public static readonly string connString = string.Empty;
        static CustomerDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;

        }

        public static List<Customer> GetAllCustomers()
        {
            List<Customer> theCustomer = new List<Customer>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "select * from Customers";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Customer theCustomers = new Customer();
                    theCustomers.ID = int.Parse(row["ID"].ToString());
                    theCustomers.Name = row["Name"].ToString();
                    theCustomers.Email = row["Email"].ToString();
                    theCustomers.Password = row["Password"].ToString();
                    theCustomers.Address = row["Address"].ToString();
                    theCustomers.ContactNumber = row["ContactNumber"].ToString();
                    theCustomers.Role = row["Role"].ToString();
                    theCustomer.Add(theCustomers);
                }

            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return theCustomer;

        }

        public static Customer GetCustomerById(int id)
        {
            Customer theCustomer = new Customer();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "select * from Customers where ID=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {

                    theCustomer.ID = int.Parse(row["Id"].ToString());
                    theCustomer.Name = row["Name"].ToString();
                    theCustomer.Email = row["Email"].ToString();
                    theCustomer.Password = row["Password"].ToString();
                    theCustomer.Address = row["Address"].ToString();
                    theCustomer.ContactNumber = row["ContactNumber"].ToString();
                    theCustomer.Role = row["Role"].ToString();
                }

            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return theCustomer;
        }

        public static bool GetCustomer(string email,string password)
        {
           /* MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@0", email);
            cmd.Parameters.AddWithValue("@1", pass);
            cmd.Parameters.AddWithValue("@2", role);
            connection.Open();
            MySqlDataReader result = cmd.ExecuteReader();

            if (result.Read())
            {
                u.ID = int.Parse(result["RoleID"].ToString());
                u.email = result["email"].ToString();
                u.role = result["accType"].ToString();

                Console.WriteLine("validate successfully ");
            }
            connection.Close();
        }
            return u;*/
            bool status = false;
            //IDbConnection con = new MySqlConnection(connString);
            MySqlConnection connection = new MySqlConnection(connString);
            string query = "Select * FROM Customers where Email=@email AND Password=@password";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Connection = connection;

            //IDbCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            connection.Open();
            MySqlDataReader result = cmd.ExecuteReader();

            if (result.Read())
            {
                status = true;
                connection.Close();
            }
            
            

            return status;
        }
        public static bool AddNewCustomer(Customer theCustomer)
        {
            {

                bool status = false;
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "INSERT INTO Customers (Name,Email, Password, Address, ContactNumber,Role) " +
                            "VALUES (@name, @email, @password, @address, @contact,@role)";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.Add(new MySqlParameter("@name", theCustomer.Name));
                        cmd.Parameters.Add(new MySqlParameter("@email", theCustomer.Email));
                        cmd.Parameters.Add(new MySqlParameter("@password", theCustomer.Password));
                        cmd.Parameters.Add(new MySqlParameter("@address", theCustomer.Address));
                        cmd.Parameters.Add(new MySqlParameter("@contact", theCustomer.ContactNumber));
                        cmd.Parameters.Add(new MySqlParameter("@role", theCustomer.Role));
                        cmd.ExecuteNonQuery();// DML
                        status = true;

                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    string message = ex.Message;
                    throw ex;
                }
                return status;


            }



        }

        
        public static Customer Update(int id,Customer theCustomer)
        {
            //bool status = false;
            IDbConnection con = new MySqlConnection(connString);
            string query = "UPDATE Customers SET Name=@name ,Email=@email,Password=@password, Address=@address, " +
                         "ContactNumber=@number,Role=@role WHERE ID="+id;
            IDbCommand cmd = new MySqlCommand(query);
            //cmd.Parameters.Add(new MySqlParameter("@id", theCustomer.ID));
            cmd.Parameters.Add(new MySqlParameter("@name", theCustomer.Name));
            cmd.Parameters.Add(new MySqlParameter("@email", theCustomer.Email));
            cmd.Parameters.Add(new MySqlParameter("@password", theCustomer.Password));
            cmd.Parameters.Add(new MySqlParameter("@address", theCustomer.Address));
            cmd.Parameters.Add(new MySqlParameter("@number", theCustomer.ContactNumber));
            cmd.Parameters.Add(new MySqlParameter("@role", theCustomer.Role));
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //status = true;
            }
            catch (MySqlException ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return theCustomer;
        }

        public static bool Delete(int id)
        {
            bool status = false;
            IDbConnection con = new MySqlConnection(connString);
            string query = "DELETE FROM Customers where ID=@id";
            IDbCommand cmd = new MySqlCommand(query);
            cmd.Parameters.Add(new MySqlParameter("@id", id));
            cmd.Connection = con;
            try
            {
                con.Open();
                var reader = cmd.ExecuteNonQuery();
                con.Close();
                status = true;

            }
            catch (MySqlException ex)
            {
                string message = ex.Message;
                throw ex;
            }

            return status;
        }
    }
}
