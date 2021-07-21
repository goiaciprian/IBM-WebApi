using IBM_WebApi.DTOs;
using IBM_WebApi.Extensions;
using IBM_WebApi.Interfaces;
using IBM_WebApi.Interfaces.IUnitsOfWork;
using IBM_WebApi.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class GpuController : ControllerBase
    {
        private readonly IStoreUnitOfWork _storeUnit;

        public GpuController(IStoreUnitOfWork repo)
        {
            _storeUnit = repo;
        }

        [HttpGet("all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<PlaciVideoDTO>>> GetAll()
        {
            return Ok((await _storeUnit.GPUs.Get()).Select(gpu => gpu.toDTO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaciVideoDTO>>> Get()
        {
            return Ok((await _storeUnit.GPUs.GetNotDeleted()).Select(gpu => gpu.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaciVideoDTO>> GetById(Guid id)
        {
            var _found = await _storeUnit.GPUs.Get(id);
            if (_found == null) return NotFound();
            else return Ok(_found.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<PlaciVideoDTO>> Add([FromBody] PlaciVideoDTO gpu)
        {
            var _created = await _storeUnit.GPUs.Add(gpu.toEntity());
            await _storeUnit.Complete();
            return CreatedAtAction(nameof(GetById), new { id = _created.ID_Gpu}, _created.toDTO());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<PlaciVideoDTO>> Update (Guid id, [FromBody] PlaciVideoDTO gpu)
        {
            if (id != gpu.ID_Gpu) return BadRequest();
            else
            {
                var _update = await _storeUnit.GPUs.Update(id, gpu.toEntity());
                await _storeUnit.Complete();
                return Ok(_update.toDTO());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlaciVideoDTO>> Delete(Guid id)
        {
            var _deleted = await _storeUnit.GPUs.Delete(id);
            await _storeUnit.Complete();
            if (_deleted == null) return NotFound();
            else return Ok(_deleted.toDTO());
        }
    }
}
