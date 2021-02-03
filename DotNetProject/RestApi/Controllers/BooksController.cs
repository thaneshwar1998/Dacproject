using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using BOL;
namespace RestApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BooksController : ApiController
    {
        // GET: api/Books
        public IEnumerable<Books> Get()
        {
            return BookManager.GetAllBooks();
        }

        // GET: api/Books/5
        public Books Get(int id)
        {
            return BookManager.GetBooks(id);
        }

        /*public Books Get(string category)
        {
            return BookManager.GetBooksByCategory(category);
        }
        */
        // POST: api/Books

        public Books Post([FromBody] Books theBooks)
        {
            /*var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            if(file !=null && file.ContentLength >0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), fileName);
                file.SaveAs(path);
            }*/
            return BookManager.InsertBook(theBooks);
            // return Ok;

        }
        //put method can be used for updating the information
        // PUT: api/Books/5

        public Books Put(int id, [FromBody] Books value)
        {
           return  BookManager.UpdateBook(id,value);
        }

        // DELETE: api/Books/5
        public bool Delete(int id)
        {
            return BookManager.DeleteById(id);
        }
    }
}
