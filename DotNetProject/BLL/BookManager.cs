using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
   public class BookManager
    {
        public static List<Books> GetAllBooks()
        {
            List<Books> allBooks = new List<Books>();
            allBooks = BookDBManager.GetAllBooks();
            return allBooks;
        }
        public static Books GetBooks(int id)
        {
            return BookDBManager.GetBooksById(id);
        }

        /*public static Books GetBooksByCategory(string category)
        {
            return BookDBManager.GetBooksByCategory(category);
        }*/
        public static Books InsertBook(Books thebook)

        {
            return BookDBManager.InsertBook(thebook);
        }
        public static Books UpdateBook(int id,Books book)
        {
            return BookDBManager.UpdateBook(id,book);
        }

        public static bool DeleteById(int id)
        {
            return BookDBManager.DeleteById(id);
        }
    }
}
