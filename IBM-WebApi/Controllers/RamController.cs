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
    public class RamController : ControllerBase
    {
        private readonly DbCrud<Ram> _ramRepo;

        public RamController(DbCrud<Ram> repo)
        {
            _ramRepo = repo;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RamDTO>>> GetAll()
        {
            return Ok((await _ramRepo.Get()).Select(ram => ram.toDTO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RamDTO>>> Get()
        {
            return Ok((await _ramRepo.GetNotDeleted()).Select(ram => ram.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RamDTO>>> GetById(Guid id)
        {
            var _found = await _ramRepo.Get(id);
            if (_found == null)
                return NotFound();
            else return Ok(_found.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<RamDTO>> Add([FromBody] RamDTO ram)
        {
            var _created = await _ramRepo.Add(ram.toEntity());
            return CreatedAtAction(nameof(GetById), new { id = _created.ID_Ram }, _created.toDTO());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<RamDTO>> Update(Guid id, [FromBody] RamDTO newRam)
        {
            if (id != newRam.ID_Ram) return BadRequest();
            else return Ok((await _ramRepo.Update(id, newRam.toEntity())).toDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RamDTO>> Delete(Guid id)
        {
            var _deleted = await _ramRepo.Delete(id);
            if (_deleted == null) return NotFound();
            else return Ok(_deleted.toDTO());
        }

    }
}
