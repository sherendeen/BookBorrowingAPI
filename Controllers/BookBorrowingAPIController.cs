using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookBorrowingAPI.Models;
using BookBorrowingAPI.Data;

namespace BookBorrowingAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookBorrowingAPIController : ControllerBase
    {
        private readonly ApiContext _context;

        public BookBorrowingAPIController(ApiContext context)
        {
            _context = context;
        }

        //Create/edit
        [HttpPost]
        public JsonResult CreateEdit(Book book)
        {
            if (book.Id == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Find(book.Id);

                if (bookInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                bookInDb = book;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(book));
        }

        //get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Books.Find(id);

            if ( result == null )
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Books.Find(id);

            if (result == null) { 
                return new JsonResult(NotFound());
            }
            _context.Books.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Books.ToList();
            return new JsonResult(Ok(result));
        }
    }
}