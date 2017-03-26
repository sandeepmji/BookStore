using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public class BookService : IDisposable, IBookService
    {
        private IBookStoreDataContext _bookStoreDataContext;
        
        public BookService()
        {
            _bookStoreDataContext = new BookStoreDataContext();
                
        }

        public BookService(IBookStoreDataContext bookStoreDataContext)
        {
            _bookStoreDataContext = bookStoreDataContext;
        }

        public IQueryable<Book> GetBooks()
        {
            return _bookStoreDataContext.Books;
        }

        public Book GetBook(int id)
        {
            Book book = _bookStoreDataContext.Books.Find(id);
            return book;
        }

        public int UpdateBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return 1;
            }

            _bookStoreDataContext.MarkAsModified<Book>(book);

            try
            {
                _bookStoreDataContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return 2;
                }
                else
                {
                    throw;
                }
            }

            return 0;
        }

        public int AddBook(Book book)
        {
            _bookStoreDataContext.Books.Add(book);
            _bookStoreDataContext.SaveChanges();

            return book.BookId;
        }

        public Book DeleteBook(int id)
        {
            Book book = _bookStoreDataContext.Books.Find(id);
            if (book == null)
            {
                return null;
            }

            _bookStoreDataContext.Books.Remove(book);
            _bookStoreDataContext.SaveChanges();

            return book;
        }
        
        private bool BookExists(int id)
        {
            return _bookStoreDataContext.Books.Count(e => e.BookId == id) > 0;
        }
        
        public void Dispose()
        {
            _bookStoreDataContext.Dispose();
        }
    }
}
