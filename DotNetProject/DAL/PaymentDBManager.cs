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
    public class PaymentDBManager
    {
        public static readonly string connString = string.Empty;
        static PaymentDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;

        }
        public static Payment NewPayment(Payment newPayment)
        {
            {

                // bool status = false;
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "INSERT INTO Payments (Name,CardNumber,CVV,Amount,PaymentDate) " +
                            "VALUES (@name,@cardnumber,@cvv,@amount,@paymentdate )";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.Add(new MySqlParameter("@name", newPayment.Name));
                        cmd.Parameters.Add(new MySqlParameter("@cardnumber", newPayment.CardNumber));
                        cmd.Parameters.Add(new MySqlParameter("@cvv", newPayment.CVV));
                        cmd.Parameters.Add(new MySqlParameter("@amount", newPayment.Amount));
                        cmd.Parameters.Add(new MySqlParameter("@paymentdate", newPayment.PaymentDate));
                        cmd.ExecuteNonQuery();// DML
                        //status = true;

                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    string message = ex.Message;
                    throw ex;
                }
                return newPayment;


            }
        }
    }
}
