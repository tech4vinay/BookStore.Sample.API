using BookStore.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Repositories
{
    public interface IBooksRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int id);
    }
}
