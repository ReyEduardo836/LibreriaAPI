using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LibreriaController : ControllerBase
    {
        private readonly LibreriaContext _context;

        public LibreriaController(LibreriaContext context) => _context = context;

        [HttpGet]
        //public async Task<IEnumerable<Libro>> Get()
        //{
        //    return await _context.Libros.ToListAsync();
        //}
        public IEnumerable<Libro> Get()
        {
            return _context.Libros.ToList();
        }

        [HttpGet("libro/{id}")]
        public ActionResult<Libro> GetBookById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }
            Libro libro = _context.Libros.FirstOrDefault(lib => lib.Id.ToString() == id);
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        public ActionResult<Libro> AddLibro(Libro libro)
        {
            if (libro == null)
            {
                return BadRequest();
            }
            _context.Libros.Add(libro);
            return Ok(_context.SaveChanges());
        }

        [HttpPut("update")]
        public ActionResult<Libro> UpdateLibro(Libro libro)
        {
            if(libro == null)
            {
                return BadRequest();
            }

            Libro lib = _context.Libros.Find(libro.Id);
            if (lib == null) return BadRequest();

            lib.Temas = libro.Temas;
            lib.Editorial = libro.Editorial;
            lib.Titulo = libro.Titulo;
            lib.Autor = libro.Autor;

            _context.Libros.Update(lib);
            return Ok(_context.SaveChanges());
        }
    }
}
