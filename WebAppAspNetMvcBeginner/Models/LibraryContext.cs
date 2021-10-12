using System.Data.Entity;

namespace WebAppAspNetMvcBeginner.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public LibraryContext() : base("LibraryEntity")
        { }
    }
}