using IBM_WebApi.Context;
using IBM_WebApi.Interfaces.IRepositories;
using IBM_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Repositories
{
    public class PcsRepository : IPcsRepository
    {
        private readonly StoreContext _storeContext;

        public PcsRepository(StoreContext context)
        {
            _storeContext = context;
        }

        public async Task<PCs> Add(PCs newObj)
        {
            newObj.ID_Pc = Guid.NewGuid();
            await _storeContext.Pcs.AddAsync(newObj);
            return newObj;
        }

        public async Task<PCs> Delete(Guid id)
        {
            var _deleted = await _storeContext.Pcs.FindAsync(id);
            _deleted.Sters = true;
            _storeContext.Entry(_deleted).State = EntityState.Modified;
            return _deleted;
        }

        public async Task<IEnumerable<PCs>> Get()
        {
            var _pcs = await _storeContext.Pcs.ToListAsync();
            _pcs.ForEach(pc =>
            {
                pc.procesor = _storeContext.Procesoare.Find(pc.ID_Cpu);
                pc.placaVideo = _storeContext.PlaciVideo.Find(pc.ID_Gpu);
                pc.ram = _storeContext.Ram.Find(pc.ID_Ram);
            });
            return _pcs.ToList();
        }

        public async Task<PCs> Get(Guid id)
        {
            var _found = await _storeContext.Pcs.Where(pc => pc.Sters == false && pc.ID_Pc == id).FirstOrDefaultAsync();
            _found.procesor = await _storeContext.Procesoare.Where(cpu => cpu.Sters == false && cpu.ID_Cpu == _found.ID_Cpu).FirstOrDefaultAsync();
            _found.placaVideo = await _storeContext.PlaciVideo.Where(gpu => gpu.Sters == false && gpu.ID_Gpu == _found.ID_Gpu).FirstOrDefaultAsync();
            _found.ram = await _storeContext.Ram.Where(ram => ram.Sters == false && ram.ID_Ram == _found.ID_Ram).FirstOrDefaultAsync();
            return _found;
        }

        public async Task<IEnumerable<PCs>> GetNotDeleted()
        {
            var _pcs = await _storeContext.Pcs.Where(pc => pc.Sters == false).ToListAsync();
            _pcs.ForEach(pc =>
            {
                pc.procesor = _storeContext.Procesoare.Find(pc.ID_Cpu);
                pc.placaVideo = _storeContext.PlaciVideo.Find(pc.ID_Gpu);
                pc.ram = _storeContext.Ram.Find(pc.ID_Ram);
            });
            return _pcs.ToList();
        }

        public async Task<PCs> Update(Guid id, PCs updateObj)
        {
            _storeContext.Entry(updateObj).State = EntityState.Modified;
            return updateObj;
        }
    }
}
