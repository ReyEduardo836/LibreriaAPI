using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities;

namespace WebApplication.AppCore.Interfaces
{
    public interface ILibrosServices : IServices<Libro>
    {
        Libro FindById(int id);
        IEnumerable<Libro> FindByName(string name);
        IEnumerable<Libro> FindByISBN(string isbn);
        IEnumerable<Libro> FindByAuthor(string authorName);
    }
}
