using BookStore.API.Data;
using BookStore.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        public readonly BookStoreDbContext _bookStoreDbContext;
        public BooksRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var data = await _bookStoreDbContext.Books.Select(a => new BookModel
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description
            }).ToListAsync();
            return data;
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            return await _bookStoreDbContext.Books.Where(a => a.Id.Equals(id)).Select(b => new BookModel
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> AddBookAsync(BookModel request)
        {
            var book = new Books
            {
                Title = request.Title,
                Description = request.Description
            };
            _bookStoreDbContext.Books.Add(book);
            await _bookStoreDbContext.SaveChangesAsync();
            return book.Id > 0;

        }

    }
}
