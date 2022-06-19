using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities;

namespace WebApplication.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetUser(string username, string password);
    }
}
