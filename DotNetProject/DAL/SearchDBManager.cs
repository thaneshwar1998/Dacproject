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
    public class SearchDBManager
    {
        public static readonly string connString = string.Empty;
        static SearchDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;

        }
        public static Books GetBooksByCategory(string category)
        {
            Books usedBooks = new Books();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "select * from Books where Category= @category";
            IDbCommand cmd = new MySqlCommand();
            cmd.Parameters.Add(new MySqlParameter("category", category));
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

                    usedBooks.ID = int.Parse(row["BookID"].ToString());
                    usedBooks.Title = row["Title"].ToString();
                    usedBooks.Author = row["Author"].ToString();
                    usedBooks.ImageUrl = row["ImageUrl"].ToString();
                    usedBooks.Description = row["Description"].ToString();
                    usedBooks.Price = double.Parse(row["Price"].ToString());
                    usedBooks.Quantity = int.Parse(row["Quantity"].ToString());
                    usedBooks.Language = row["Language"].ToString();
                    usedBooks.Category = row["Category"].ToString();
                    usedBooks.Rating = int.Parse(row["Rating"].ToString());
                    usedBooks.Condition = row["BookCondition"].ToString();
                }

            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return usedBooks;
        }
    }
}
