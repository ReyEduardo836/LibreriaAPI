using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.AppCore.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(userService.GetAll());
        }

        [HttpPost("create")]
        public ActionResult<User> Create(User user)
        {
            if (user == null) return BadRequest();
            return Ok(userService.Create(user));
        }

        [HttpPost("login")]
        public ActionResult<string> login(Login login)
        {
            if (string.IsNullOrWhiteSpace(login.username) & string.IsNullOrWhiteSpace(login.password)) return BadRequest("Todos los campos son obligatorios");
            if (string.IsNullOrWhiteSpace(login.username) || string.IsNullOrWhiteSpace(login.password)) return BadRequest("Todos los campos son obligatorios");

            try
            {
                return Ok(userService.Login(login.username, login.password));
            }
            catch (Exception)
            {
                return StatusCode(401);
            }
        }
    }
}
