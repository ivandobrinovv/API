using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_basic_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace API_basic_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<User> Users = new List<User>
        {
            new User
            {
                Id = new Guid("ac482a6f-4eef-495b-9c72-cdbfb953a09d"),
                Name = "Georgi",
                Birthday = new DateTime(2000, 12, 11)
            },

            new User
            {
                Id = new Guid("0e8d21ae-14fc-412e-86e6-f0b481db74e9"),
                Name = "Strahil",
                Birthday = new DateTime(1998, 8, 3)
            },
            
            new User
            {
                Id = new Guid("79b5907b-575b-492e-b830-df1cdaf1aa8d"),
                Name = "Petar",
                Birthday = new DateTime(1999, 10, 10)
            },
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = Users.SingleOrDefault(u => u.Id == id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            Users.Add(user);

            return Created(Request.GetDisplayUrl(), user);
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            var userFromDb = Users.SingleOrDefault(x => x.Id == user.Id);

            if (user == null)
            {
                return NotFound();
            }

            Users.Remove(userFromDb);
            Users.Add(user);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var user = Users.SingleOrDefault(x => x.Id == id);

            if(user == null)
            {
                return NotFound();
            }

            Users.Remove(user);

            return Ok();
        }
    }
}
