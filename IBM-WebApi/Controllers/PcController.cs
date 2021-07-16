using IBM_WebApi.DTOs;
using IBM_WebApi.Extensions;
using IBM_WebApi.Interfaces.IUnitsOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcController : ControllerBase
    {
        private readonly IStoreUnitOfWork _storeUnit;

        public PcController(IStoreUnitOfWork store)
        {
            _storeUnit = store;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PcsGetDTO>>> GetAll()
        {
            return Ok((await _storeUnit.Pcs.Get()).Select(pc => pc.toTDO()).ToList());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PcsGetDTO>>> Get()
        {
            return Ok((await _storeUnit.Pcs.GetNotDeleted()).Select(pc => pc.toTDO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PcsGetDTO>> GetbyId(Guid id)
        {
            var _found = await _storeUnit.Pcs.Get(id);
            if (_found == null) return NotFound();
            else return Ok(_found.toTDO());
        }
        [HttpPost]
        public async Task<ActionResult<PcsGetDTO>> Add([FromBody] PcsEditDTO pc)
        {
            var _added = await _storeUnit.Pcs.Add(pc.toEntity());
            await _storeUnit.Complete();
            return CreatedAtAction(nameof(GetbyId), new { id = _added.ID_Pc }, (await _storeUnit.Pcs.Get(_added.ID_Pc)).toTDO());
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<PcsGetDTO>> Update(Guid id, [FromBody] PcsEditDTO pc)
        {
            if (id != pc.ID_Pc)
                return BadRequest();
            else
            {
                var _updated = await _storeUnit.Pcs.Update(id, pc.toEntity());
                await _storeUnit.Complete();
                return Ok((await _storeUnit.Pcs.Get(_updated.ID_Pc)).toTDO());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PcsGetDTO>> Delete(Guid id)
        {
            var _deleted = await _storeUnit.Pcs.Delete(id);
            await _storeUnit.Complete();
            return Ok(_deleted.toTDO());
        }

    }
}
