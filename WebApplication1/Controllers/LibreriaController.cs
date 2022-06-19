using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.AppCore.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LibreriaController : ControllerBase
    {
        private ILibroService librosServices;

        public LibreriaController(ILibroService context) => librosServices = context;

        [HttpGet]
        public IEnumerable<Libro> Get()
        {
            return librosServices.GetAll();
        }

        [HttpGet("libro/{id}")]
        public ActionResult<Libro> GetBookById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            Libro libro = librosServices.FindById(id);
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
            return Ok(librosServices.Create(libro));
        }

        [HttpPut("update")]
        public ActionResult<Libro> UpdateLibro(Libro libro)
        {
            if (libro == null)
            {
                return BadRequest();
            }
            int lib = librosServices.Update(libro);
            if (lib == 0) return BadRequest();
            return Ok(lib);
        }
    }
}
