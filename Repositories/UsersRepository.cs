using BookStore.API.Data;
using BookStore.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public readonly BookStoreDbContext _bookStoreDbContext;
        public UsersRepository(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<UserModel> MatchUser(string name, string password)
        {
            var data = await _bookStoreDbContext.Users.Where(a => a.Name.Equals(name) && a.Password.Equals(password)).Select(a => new UserModel
            {
                Id = a.Id,
                Name = a.Name
            }).FirstOrDefaultAsync();
            return data;
        }
    }
}
