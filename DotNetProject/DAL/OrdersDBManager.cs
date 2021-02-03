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
    public class OrdersDBManager
    {
        public static readonly string connString = string.Empty;
        static OrdersDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;

        }

        public static List<OrderDetails> GetAllOrders()
        {
            List<OrderDetails> theOrder = new List<OrderDetails>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "select * from Orders";
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
                    OrderDetails theOrders = new OrderDetails();
                    theOrders.OrderID = int.Parse(row["OrderId"].ToString());
                    
                    theOrders.OrderName = row["Title"].ToString();
                    theOrders.Quantity =int.Parse(row["Quantity"].ToString());
                    theOrders.TotalAmount =double.Parse( row["TotalAmount"].ToString());
                    theOrders.OrderDate =DateTime.Parse( row["OrderDate"].ToString());
                    theOrder.Add(theOrders);
                }

            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return theOrder;

        }

        public static OrderDetails GetOrderById(int id)
        {
            OrderDetails order = new OrderDetails();
            //Books newBook = new Books();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "select * from Books where BookId=" + id;
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
                   /* newBook.Title=row["Title"].ToString();
                    newBook.Price = double.Parse(row["Price"].ToString());
                    newBook.Quantity=int.Parse(row["Quantity"].ToString());*/
                    order.OrderID = int.Parse(row["OrderId"].ToString());
                    
                    order.OrderName = row["Title"].ToString();
                    order.TotalAmount = double.Parse(row["TotalAmount"].ToString());
                    order.Quantity = int.Parse(row["Quantity"].ToString());
                    order.OrderDate =DateTime.Parse( row["OrderDate"].ToString());

                }

            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return order;
        }
        public static OrderDetails NewOrder(OrderDetails newOrder)
        {
            {

                bool status = false;
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "INSERT INTO Orders (OrderName,Price,TotalPrice,Quantity, OrderDate) " +
                            "VALUES (@ordername,@price,@amount, @quantity, @orderdate)";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.Add(new MySqlParameter("@ordername", newOrder.OrderName));
                        cmd.Parameters.Add(new MySqlParameter("@price", newOrder.Price));
                        cmd.Parameters.Add(new MySqlParameter("@amount", newOrder.TotalAmount));
                        cmd.Parameters.Add(new MySqlParameter("@quantity", newOrder.Quantity));
                        cmd.Parameters.Add(new MySqlParameter("@orderdate", newOrder.OrderDate));
                        

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
                return newOrder;


            }



        }

        
        public static bool Update(OrderDetails existingOrder)
        {
            bool status = false;
            IDbConnection con = new MySqlConnection(connString);
            string query = "UPDATE Orders SET Quantity=@quantity  WHERE OrderId=@Id";
            IDbCommand cmd = new MySqlCommand(query);
            cmd.Parameters.Add(new MySqlParameter("@Id", existingOrder.OrderID));
            cmd.Parameters.Add(new MySqlParameter("@quantity", existingOrder.Quantity));
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
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

        public static bool Delete(int id)
        {
            bool status = false;
            IDbConnection con = new MySqlConnection(connString);
            string query = "DELETE FROM Orders where OrderId=@id";
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
