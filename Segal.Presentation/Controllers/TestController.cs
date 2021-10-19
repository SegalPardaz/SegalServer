using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Segal.Data.DatabaseContext;
using Segal.Data.Models;
using Segal.Repo.Infrastructure;
using Segal.Services.Interfaces;

namespace Segal.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IUnitOfWork<SegalDbContext> _db { get; set; }
        private IAuthService _authService;

        public TestController(IUnitOfWork<SegalDbContext> db, IAuthService authService)
        {
            _db = db;
            _authService = authService;
        }

        // GET: api/Test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            User user = new User
            {
                UserName = "behbood",
                Name = "mohammad amin",
                Address = "sssssss",
                PhoneNumber = "0999",

                PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, },

                IsActive = false,
                Status = true

            };

          var regiterd=  await _authService.Register(user, "asda32");

            return Ok(regiterd);
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}