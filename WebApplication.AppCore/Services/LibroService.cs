using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.AppCore.Interfaces;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Interfaces;

namespace WebApplication.AppCore.Services
{
    public class LibroService : ILibroService
    {
        private ILibroRepository librosRepository;
        public LibroService(ILibroRepository librosRepository)
        {
            this.librosRepository = librosRepository;
        }

        public int Create(Libro t)
        {
            return librosRepository.Create(t);
        }

        public bool Delete(Libro t)
        {
            return librosRepository.Delete(t);
        }

        public IEnumerable<Libro> FindByAuthor(string authorName)
        {
            return librosRepository.FindByAuthor(authorName);
        }

        public Libro FindById(int id)
        {
            return librosRepository.FindById(id);
        }

        public IEnumerable<Libro> FindByISBN(string isbn)
        {
            return librosRepository.FindByISBN(isbn);
        }

        public IEnumerable<Libro> FindByName(string name)
        {
            return librosRepository.FindByName(name);
        }

        public IEnumerable<Libro> GetAll()
        {
            return librosRepository.GetAll();
        }

        public int Update(Libro t)
        {
            return librosRepository.Update(t);
        }
    }
}
