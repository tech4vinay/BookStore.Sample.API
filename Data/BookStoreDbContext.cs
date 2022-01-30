using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Data
{
    public class BookStoreDbContext: DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> dbContextOptions)
            :base(dbContextOptions)
        {


        }

        public DbSet<Books> Books { get; set; }
    }
}
