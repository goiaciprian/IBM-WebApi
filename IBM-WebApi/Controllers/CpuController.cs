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
    public class CpuController : ControllerBase
    {
        private readonly DbCrud<Procesoare> _cpuRepo;

        public CpuController(DbCrud<Procesoare> repo)
        {
            _cpuRepo = repo;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProcesoareDTO>>> GetAll()
        {
            return Ok((await _cpuRepo.Get()).Select(cpu => cpu.toDTO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcesoareDTO>>> Get()
        {
            return Ok((await _cpuRepo.GetNotDeleted()).Select(cpu => cpu.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProcesoareDTO>>> GetById(Guid id)
        {
            var _found = await _cpuRepo.Get(id);
            if (_found == null) return NotFound();
            else return Ok(_found.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<ProcesoareDTO>> Add ([FromBody] ProcesoareDTO cpu)
        {
            var _created = await _cpuRepo.Add(cpu.toEntity());
            return CreatedAtAction(nameof(GetById), new { id = _created.ID_Cpu }, _created);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ProcesoareDTO>> Update(Guid id, [FromBody] ProcesoareDTO cpu)
        {
            if (id != cpu.ID_Cpu) return BadRequest();
            else return Ok((await _cpuRepo.Update(id, cpu.toEntity())).toDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProcesoareDTO>> Delete(Guid id)
        {
            var _deleted = await _cpuRepo.Delete(id);
            if (_deleted == null) return NotFound();
            else return Ok(_deleted.toDTO());
        }
    }
}
