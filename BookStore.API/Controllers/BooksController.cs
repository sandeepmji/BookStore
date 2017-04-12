using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookStore.Models;
using BookStore.Service;

namespace BookStore.API.Controllers
{
    public class BooksController : ApiController
    {
        private IBookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/Books
        public IQueryable<Book> GetBooks()
        {
            return _bookService.GetBooks();
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public Book GetBook(int id)
        {
            Book book = _bookService.GetBook(id);
            if (book == null)
            {
                return null;
            }

            return book;
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.BookId)
            {
                return BadRequest();
            }

            var result = _bookService.UpdateBook(id, book);
            
            if (result == 2)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _bookService.AddBook(book);

            return CreatedAtRoute("DefaultApi", new { id = result }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            var result = _bookService.DeleteBook(id);

            return Ok(result);
        }
    }
}