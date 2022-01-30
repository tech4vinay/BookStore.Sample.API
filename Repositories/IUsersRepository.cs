using BookStore.API.Model;
using System.Threading.Tasks;

namespace BookStore.API.Repositories
{
    public interface IUsersRepository
    {
        Task<UserModel> MatchUser(string name, string password);
    }
}