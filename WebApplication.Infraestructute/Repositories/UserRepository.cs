using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Interfaces;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebApplication.Infraestructute.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ILibreriaContext context;
        public UserRepository(ILibreriaContext context)
        {
            this.context = context;
        }
        public int Create(User t)
        {
            t.Password = BCryptNet.HashPassword(t.Password);
            context.Users.Add(t);
            return context.SaveChanges();
        }

        public bool Delete(User t)
        {
            context.Users.Remove(t);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User? GetUser(string username, string password)
        {
            User? user = context.Users.Where(user => user.Username == username).FirstOrDefault();
            bool auth = BCryptNet.Verify(password, user.Password);
            if (!auth)
            {
                return null;
            }
            return user;
        }

        public int Update(User t)
        {
            context.Users.Update(t);
            return context.SaveChanges();
        }
    }
}
