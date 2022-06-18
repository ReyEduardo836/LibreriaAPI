using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Interfaces;

namespace WebApplication.Infraestructute.Repositories
{
    public class LibrosRepository : ILibrosRepository
    {
        private LibreriaContext context;

        public LibrosRepository(LibreriaContext context)
        {
            this.context = context;
        }

        public int Create(Libro t)
        {
            context.Libros.Add(t);
            return context.SaveChanges();
        }

        public bool Delete(Libro t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> FindByAuthor(string authorName)
        {
            throw new NotImplementedException();
        }

        public Libro FindById(int id)
        {
            return context.Libros.Find(id);
        }

        public IEnumerable<Libro> FindByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> GetAll()
        {
            return context.Libros.ToList();
        }

        public int Update(Libro t)
        {
            Libro lib = context.Libros.Find(t.Id);
            if (lib == null) return 0;

            lib.Temas = t.Temas;
            lib.Editorial = t.Editorial;
            lib.Titulo = t.Titulo;
            lib.Autor = t.Autor;

            context.Libros.Update(lib);
            return context.SaveChanges();
        }
    }
}
