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
            return await _storeContext.Pcs
                .Include(pc => pc.procesor)
                .Include(pc => pc.placaVideo)
                .Include(pc => pc.ram)
                .ToListAsync();
        }

        public async Task<PCs> Get(Guid id)
        {
            return await _storeContext.Pcs
                .Where(pc => pc.Sters == false && pc.ID_Pc == id)
                .Include(pc => pc.procesor)
                .Include(pc => pc.placaVideo)
                .Include(pc => pc.ram)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PCs>> GetNotDeleted()
        {
            return await _storeContext.Pcs
                .Where(pc => pc.Sters == false)
                .Include(pc => pc.procesor)
                .Include(pc => pc.placaVideo)
                .Include(pc => pc.ram)
                .ToListAsync();
        }

        public async Task<PCs> Update(Guid id, PCs updateObj)
        {
            await Task.Run(() =>_storeContext.Entry(updateObj).State = EntityState.Modified);
            return updateObj;
        }
    }
}
