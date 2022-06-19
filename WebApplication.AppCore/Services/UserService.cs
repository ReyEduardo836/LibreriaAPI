using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication.AppCore.Interfaces;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Interfaces;

namespace WebApplication.AppCore.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private AppSetting appSetting;
        public UserService(IUserRepository userRepository, IOptions<AppSetting> appSetting)
        {
            this.userRepository = userRepository;
            this.appSetting = appSetting.Value;
        }

        public int Create(User t)
        {
            return userRepository.Create(t);
        }

        public bool Delete(User t)
        {
            return userRepository.Delete(t);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public bool IsTokenValid(string token)
        {
            return false;
        }

        public string Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Username or password no valid");
            }
            User? user = userRepository.GetUser(username, password);
            if(user == null)
            {
                throw new Exception("Username or password no valid");
            }
            string token = GenerateToken(user);
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("Username or password no valid");
            }
            return token;
        }

        public int Update(User t)
        {
            throw new NotImplementedException();
        }

        private string GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username)
                //new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.Role, user.Role)
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: appSetting.issuer,
                audience: appSetting.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSetting.SecretKey)),
                    SecurityAlgorithms.HmacSha256Signature)
                );

            string token = tokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}