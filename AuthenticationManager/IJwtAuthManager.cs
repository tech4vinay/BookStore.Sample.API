using System.Threading.Tasks;

namespace BookStore.API.AuthenticationManager
{
    public interface IJwtAuthManager
    {
        Task<string> Authenticate(string username, string password);
    }
}
