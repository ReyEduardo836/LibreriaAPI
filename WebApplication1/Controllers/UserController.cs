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

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            if (user == null) return BadRequest();
            return Ok(userService.Create(user));
        }

        [HttpPost("login")]
        public ActionResult<string> login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) & string.IsNullOrWhiteSpace(password)) return BadRequest();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return BadRequest();

            try
            {
                return Ok(userService.Login(username, password));
            }
            catch (Exception)
            {
                return StatusCode(401);
            }
        }
    }
}
