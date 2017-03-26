using System.Linq;
using BookStore.Models;

namespace BookStore.Service
{
    public interface IBookService
    {
        int AddBook(Book book);
        Book DeleteBook(int id);
        Book GetBook(int id);
        IQueryable<Book> GetBooks();
        int UpdateBook(int id, Book book);
    }
}