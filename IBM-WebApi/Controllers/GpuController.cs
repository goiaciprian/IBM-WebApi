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
    public class GpuController : ControllerBase
    {
        private readonly DbCrud<PlaciVideo> _gpuRepo;

        public GpuController(DbCrud<PlaciVideo> repo)
        {
            _gpuRepo = repo;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PlaciVideoDTO>>> GetAll()
        {
            return Ok((await _gpuRepo.Get()).Select(gpu => gpu.toDTO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaciVideoDTO>>> Get()
        {
            return Ok((await _gpuRepo.GetNotDeleted()).Select(gpu => gpu.toDTO()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaciVideoDTO>> GetById(Guid id)
        {
            var _found = await _gpuRepo.Get(id);
            if (_found == null) return NotFound();
            else return Ok(_found.toDTO());
        }

        [HttpPost]
        public async Task<ActionResult<PlaciVideoDTO>> Add([FromBody] PlaciVideoDTO gpu)
        {
            var _created = await _gpuRepo.Add(gpu.toEntity());
            return CreatedAtAction(nameof(GetById), new { id = _created.ID_Gpu}, _created.toDTO());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<PlaciVideoDTO>> Update (Guid id, [FromBody] PlaciVideoDTO gpu)
        {
            if (id != gpu.ID_Gpu) return BadRequest();
            else return Ok((await _gpuRepo.Update(id, gpu.toEntity())).toDTO());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlaciVideoDTO>> Delete(Guid id)
        {
            var _deleted = await _gpuRepo.Delete(id);
            if (_deleted == null) return NotFound();
            else return Ok(_deleted.toDTO());
        }
    }
}
