using BookStore.API.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.API.AuthenticationManager
{
    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _configuration;

        public JwtAuthManager(IUsersRepository usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<string> Authenticate(string username, string password)
        {
            var user = await _usersRepository.MatchUser(username, password);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var privateKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("PrivateKey"));
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokendescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
