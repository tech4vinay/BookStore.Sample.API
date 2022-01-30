using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> dbContextOptions)
            : base(dbContextOptions)
        {


        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
