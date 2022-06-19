using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities;

namespace WebApplication.AppCore.Interfaces
{
    public interface IUserService : IServices<User>
    {
        string Login(string username, string password);
        bool IsTokenValid(string token);
    }
}
