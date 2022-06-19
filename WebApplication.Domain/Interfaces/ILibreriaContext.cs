using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.Domain.Entities;

namespace WebApplication.Domain.Interfaces
{
    public interface ILibreriaContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<User> Users { get; set; }

        public int SaveChanges();
        public Task<int> SaveChangesAsync(CancellationToken cancelationToken);
    }
}
