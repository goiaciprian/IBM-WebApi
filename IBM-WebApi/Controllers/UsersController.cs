using IBM_WebApi.DTOs;
using IBM_WebApi.Extensions;
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
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetDeleted()
        {
            return Ok((await _userRepo.Get()).Select(user => user.toDTO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            return Ok((await _userRepo.GetNotDeleted()).Select(user => user.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetId(Guid id)
        {
            var _user = await _userRepo.Get(id);
            if (_user == null)
                return NotFound();
            else return Ok(_user.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Add([FromBody] UserDTO newUser )
        {
            var _created = await _userRepo.Add(newUser.toEntity());
            return CreatedAtAction(nameof(GetId), new { id = _created.Id_User}, _created.toDTO());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<UserDTO>> Update (Guid id, [FromBody] UserDTO updateUser)
        {
            if (id != updateUser.Id_User)
                return BadRequest();
            else return Ok((await _userRepo.Update(id, updateUser.toEntity())).toDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete (Guid id)
        {
            var _deleted = await _userRepo.Delete(id);
            if (_deleted == null)
                return NotFound();
            else return Ok(_deleted.toDTO());
        }
    }
}
