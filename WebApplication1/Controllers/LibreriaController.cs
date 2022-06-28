using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.AppCore.Interfaces;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Constants;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[Controller]")]
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
        [Authorize(Policy = "AdminAccess")]
        public ActionResult<Libro> AddLibro(Libro libro)
        {
            if (libro == null)
            {
                return BadRequest();
            }
            return Ok(librosServices.Create(libro));
        }

        [HttpPut("update")]
        [Authorize(Roles = Roles.administrador)]
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
