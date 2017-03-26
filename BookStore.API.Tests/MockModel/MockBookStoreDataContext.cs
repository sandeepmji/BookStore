using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BookStore.API.Tests.MockModel
{
    public class MockBookStoreDataContext : IBookStoreDataContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public void Dispose()
        {
            this.Books = new MockBookDbSet();
            this.Authors = new MockAuthorDbSet();
        }

        public void MarkAsModified<T>(T Item) where T : class
        {
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
