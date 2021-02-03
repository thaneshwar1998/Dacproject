using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using BOL;
using System.IO;

namespace DAL
{
    public class BookDBManager
    {
        public static readonly string connString = string.Empty;
        static BookDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;

        }

        public static Books GetBooksById(int id)
        {
            Books usedBooks = new Books();
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
        public static List<Books> GetAllBooks()
        {
            List<Books> theBook = new List<Books>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "select * from Books";
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
                    Books theBooks = new Books();
                    theBooks.ID = int.Parse(row["BookId"].ToString());
                    theBooks.Title = row["Title"].ToString();
                    theBooks.Author = row["Author"].ToString();
                    theBooks.Description = row["Description"].ToString();
                    theBooks.ImageUrl = row["ImageUrl"].ToString();
                    theBooks.Price = double.Parse(row["Price"].ToString());
                    theBooks.Quantity = int.Parse(row["Quantity"].ToString());
                    theBooks.Language = row["Language"].ToString();
                    theBooks.Category = row["Category"].ToString();
                    theBooks.Rating = int.Parse(row["Rating"].ToString());
                    theBooks.Condition = row["BookCondition"].ToString();
                    theBook.Add(theBooks);
                }

            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return theBook;

        }
        public static Books InsertBook(Books theBook)
        {
            {
                
                // theBook = new Books();
                // bool status = false;
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "INSERT INTO Books (Title,Author, ImageUrl, Description, Price,Quantity,Language,Category,Rating,BookCondition) " +
                            "VALUES ( @title, @author, @imageurl, @description, @price,@quantity,@language,@category,@rating,@condition)";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        //cmd.Parameters.Add(new MySqlParameter("@id", theBook.ID));
                        cmd.Parameters.Add(new MySqlParameter("@title", theBook.Title));
                        cmd.Parameters.Add(new MySqlParameter("@author", theBook.Author));
                        cmd.Parameters.Add(new MySqlParameter("@imageurl", theBook.ImageUrl));
                        cmd.Parameters.Add(new MySqlParameter("@description", theBook.Description));
                        cmd.Parameters.Add(new MySqlParameter("@price", theBook.Price));
                        cmd.Parameters.Add(new MySqlParameter("@quantity", theBook.Quantity));
                        cmd.Parameters.Add(new MySqlParameter("@language", theBook.Language));
                        cmd.Parameters.Add(new MySqlParameter("@category", theBook.Category));
                        cmd.Parameters.Add(new MySqlParameter("@rating", theBook.Rating));
                        cmd.Parameters.Add(new MySqlParameter("@condition", theBook.Condition));
                        cmd.ExecuteNonQuery();// DML

                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    string message = ex.Message;
                    throw ex;
                }
                return theBook;


            }



        }
        public static Books UpdateBook(int id,Books theBook)
        {
           // bool status = false;
            //Books thebook = new Books();
            IDbConnection con = new MySqlConnection(connString);
            string query = "UPDATE Books SET Title=@Title ,Author=@Author,ImageUrl=@Image, Description=@Description, " +
                         "Price=@Price, Quantity=@Quantity,Language=@language,Category=@category,Rating=@rating,BookCondition=@condition " +
                        "WHERE BookID="+id;
            IDbCommand cmd = new MySqlCommand(query);
            //cmd.Parameters.Add(new MySqlParameter("@Id", theBook.ID));
            cmd.Parameters.Add(new MySqlParameter("@Title", theBook.Title));
            cmd.Parameters.Add(new MySqlParameter("@Author", theBook.Author));
            cmd.Parameters.Add(new MySqlParameter("@Image", theBook.ImageUrl));
            cmd.Parameters.Add(new MySqlParameter("@Description", theBook.Description));
            cmd.Parameters.Add(new MySqlParameter("@Price", theBook.Price));
            cmd.Parameters.Add(new MySqlParameter("@Quantity", theBook.Quantity));
            cmd.Parameters.Add(new MySqlParameter("@language", theBook.Language));
            cmd.Parameters.Add(new MySqlParameter("@category", theBook.Category));
            cmd.Parameters.Add(new MySqlParameter("@rating", theBook.Rating));
            cmd.Parameters.Add(new MySqlParameter("@condition", theBook.Condition));
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

            return theBook;
        }
        public static bool DeleteById(int id)
        {
            bool status = false;
            IDbConnection con = new MySqlConnection(connString);
            string query = "DELETE FROM Books where BookID=@id";
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
