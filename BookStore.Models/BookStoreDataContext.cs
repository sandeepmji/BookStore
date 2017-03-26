using System;
using System.Data.Entity;

namespace BookStore.Models
{
    public class BookStoreDataContext : DbContext, IBookStoreDataContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public void MarkAsModified<T>(T item) where T : class
        {
            Entry<T>(item).State = EntityState.Modified;
        }
    }
}