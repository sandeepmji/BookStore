using System.Data.Entity;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public interface IBookStoreDataContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        int SaveChanges();

        void MarkAsModified<T>(T Item) where T:class;
        void Dispose();
    }
}