using IBM_WebApi.Interfaces;
using IBM_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DbCrud<User> _userRepo;

        public UsersController(DbCrud<User> userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetDeleted()
        {
            return Ok(await _userRepo.Get());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _userRepo.GetNotDeleted());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetId(Guid id)
        {
            var _user = await _userRepo.Get(id);
            if (_user == null)
                return NotFound();
            else return Ok(_user);
        }

        [HttpPost]
        public async Task<User> Add([FromBody] User newUser )
        {
            return await _userRepo.Add(newUser);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<User>> Update (Guid id, [FromBody] User updateUser)
        {
            if (id != updateUser.Id_User)
                return BadRequest();
            else return Ok(await _userRepo.Update(id, updateUser));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete (Guid id)
        {
            var _deleted = await _userRepo.Delete(id);
            if (_deleted == null)
                return NotFound();
            else return Ok(_deleted);
        }
    }
}
