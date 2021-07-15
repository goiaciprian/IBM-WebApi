using IBM_WebApi.DTOs;
using IBM_WebApi.Extensions;
using IBM_WebApi.Interfaces.IUnitsOfWork;
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
        private readonly IUserUnitOfWork _userUnit;

        public UsersController(IUserUnitOfWork userUnit)
        {
            _userUnit = userUnit;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetDeleted()
        {
            return Ok((await _userUnit.Users.Get()).Select(user => user.toDTO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            return Ok((await _userUnit.Users.GetNotDeleted()).Select(user => user.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetId(Guid id)
        {
            var _user = await _userUnit.Users.Get(id);
            if (_user == null)
                return NotFound();
            else return Ok(_user.toDTO());
        }

        [HttpGet("admins")]
        public async Task<ActionResult<UserDTO>> GetAdmins()
        {
            return Ok((await _userUnit.Users.GetAdminUsers()).Select(user => user.toDTO()).ToList());
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Add([FromBody] UserDTO newUser )
        {
            var _created = await _userUnit.Users.Add(newUser.toEntity());
            await _userUnit.Complete();
            return CreatedAtAction(nameof(GetId), new { id = _created.Id_User}, _created.toDTO());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<UserDTO>> Update (Guid id, [FromBody] UserDTO updateUser)
        {
            if (id != updateUser.Id_User)
                return BadRequest();
            else
            {
                var _updated = (await _userUnit.Users.Update(id, updateUser.toEntity())).toDTO();
                await _userUnit.Complete();
                return Ok(_updated);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete (Guid id)
        {
            var _deleted = await _userUnit.Users.Delete(id);
            await _userUnit.Complete();
            if (_deleted == null)
                return NotFound();
            else return Ok(_deleted.toDTO());
        }
    }
}
