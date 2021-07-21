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
    public class CpuController : ControllerBase
    {
        private readonly IStoreUnitOfWork _storeUnit;

        public CpuController(IStoreUnitOfWork unit)
        {
            _storeUnit = unit;
        }

        [HttpGet("all"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ProcesoareDTO>>> GetAll()
        {
            return Ok((await _storeUnit.CPUs.Get()).Select(cpu => cpu.toDTO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcesoareDTO>>> Get()
        {
            return Ok((await _storeUnit.CPUs.GetNotDeleted()).Select(cpu => cpu.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProcesoareDTO>>> GetById(Guid id)
        {
            var _found = await _storeUnit.CPUs.Get(id);
            if (_found == null) return NotFound();
            else return Ok(_found.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<ProcesoareDTO>> Add ([FromBody] ProcesoareDTO cpu)
        {
            var _created = await _storeUnit.CPUs.Add(cpu.toEntity());
            await _storeUnit.Complete();
            return CreatedAtAction(nameof(GetById), new { id = _created.ID_Cpu }, _created);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ProcesoareDTO>> Update(Guid id, [FromBody] ProcesoareDTO cpu)
        {
            if (id != cpu.ID_Cpu) return BadRequest();
            else
            {
                var _update = await _storeUnit.CPUs.Update(id, cpu.toEntity());
                await _storeUnit.Complete();
                return Ok(_update.toDTO());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProcesoareDTO>> Delete(Guid id)
        {
            var _deleted = await _storeUnit.CPUs.Delete(id);
            await _storeUnit.Complete();
            if (_deleted == null) return NotFound();
            else return Ok(_deleted.toDTO());
        }
    }
}
