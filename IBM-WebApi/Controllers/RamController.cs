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
    public class RamController : ControllerBase
    {
        private readonly IStoreUnitOfWork _storeUnit;

        public RamController(IStoreUnitOfWork repo)
        {
            _storeUnit = repo;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RamDTO>>> GetAll()
        {
            return Ok((await _storeUnit.Rams.Get()).Select(ram => ram.toDTO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RamDTO>>> Get()
        {
            return Ok((await _storeUnit.Rams.GetNotDeleted()).Select(ram => ram.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RamDTO>>> GetById(Guid id)
        {
            var _found = await _storeUnit.Rams.Get(id);
            if (_found == null)
                return NotFound();
            else return Ok(_found.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<RamDTO>> Add([FromBody] RamDTO ram)
        {
            var _created = await _storeUnit.Rams.Add(ram.toEntity());
            await _storeUnit.Complete();
            return CreatedAtAction(nameof(GetById), new { id = _created.ID_Ram }, _created.toDTO());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<RamDTO>> Update(Guid id, [FromBody] RamDTO newRam)
        {
            if (id != newRam.ID_Ram) return BadRequest();
            else
            {
                var _update = await _storeUnit.Rams.Update(id, newRam.toEntity());
                await _storeUnit.Complete();
                return Ok(_update.toDTO());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RamDTO>> Delete(Guid id)
        {
            var _deleted = await _storeUnit.Rams.Delete(id);
            await _storeUnit.Complete();
            if (_deleted == null) return NotFound();
            else return Ok(_deleted.toDTO());
        }

    }
}
