using IBM_WebApi.DTOs;
using IBM_WebApi.Extensions;
using IBM_WebApi.Interfaces.IUnitsOfWork;
using IBM_WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IBM_WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserUnitOfWork _userUnit;
        private readonly IConfiguration _configuration;

        public UsersController(IUserUnitOfWork userUnit, IConfiguration configuration)
        {
            _userUnit = userUnit;
            _configuration = configuration;
        }

        [HttpGet("all"), Authorize(Roles = "Admin")]
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

        [HttpGet("admins"), Authorize(Roles = "Admin")]
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

        [HttpPost("login")]
        public async Task<ActionResult<string>> LogIn([FromBody] LogInDTO credentials)
        {
            var _user = await _userUnit.Users.GetOnLogIn(credentials.Email, credentials.Parola);
            if (_user == null) return BadRequest();

            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var _singinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var _claims = new List<Claim>();
            if (_user.isAdmin)
                _claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var _tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:44325",
                audience: "https://localhost:44325",
                claims: _claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: _singinCredentials
            );

            var _tokenString = new JwtSecurityTokenHandler().WriteToken(_tokenOptions);
            return Ok(new { Toke = _tokenString });
        }

        [HttpPost("{id}"), Authorize]
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

        [HttpDelete("{id}"), Authorize]
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
