using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service
{
    public class BookService: IDisposable
    {
        private IBookStoreDataContext _bookStoreDataContext;
        
        public BookService()
        {
                
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

        public int PutBook(int id, Book book)
        {
            if (id != book.BookId)
            {
                return 1;
            }

            _bookStoreDataContext.MarkAsModified<Book>();

            try
            {
                _bookStoreDataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }

            return 0;
        }

        public int PostBook(Book book)
        {
            _bookStoreDataContext.Books.Add(book);
            _bookStoreDataContext.SaveChangesAsync();

            return book.BookId;
        }

        public int DeleteBook(int id)
        {
            Book book = _bookStoreDataContext.Books.FindAsync(id);
            if (book == null)
            {
                return 1;
            }

            _bookStoreDataContext.Books.Remove(book);
            _bookStoreDataContext.SaveChangesAsync();

            return book;
        }
        
        private bool BookExists(int id)
        {
            return _bookStoreDataContext.Books.Count(e => e.BookId == id) > 0;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookStoreDataContext.Dispose();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
