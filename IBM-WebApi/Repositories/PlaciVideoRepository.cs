using IBM_WebApi.Context;
using IBM_WebApi.Interfaces;
using IBM_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Repositories
{
    public class PlaciVideoRepository : DbCrud<PlaciVideo>
    {
        private readonly StoreContext _storeContext;

        public PlaciVideoRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<PlaciVideo> Add(PlaciVideo newObj)
        {
            newObj.ID_Gpu = Guid.NewGuid();
            await _storeContext.PlaciVideo.AddAsync(newObj);
            await _storeContext.SaveChangesAsync();
            return newObj;
        }

        public async Task<PlaciVideo> Delete(Guid id)
        {
            var _deleted = await _storeContext.PlaciVideo.FindAsync(id);
            _deleted.Sters = true;
            _storeContext.Entry(_deleted).State = EntityState.Modified;
            await _storeContext.SaveChangesAsync();
            return _deleted;
        }

        public async Task<IEnumerable<PlaciVideo>> Get()
        {
            return await _storeContext.PlaciVideo.ToListAsync();
        }

        public async Task<PlaciVideo> Get(Guid id)
        {
            return await _storeContext.PlaciVideo.Where(placaVideo => placaVideo.Sters == false && placaVideo.ID_Gpu == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlaciVideo>> GetNotDeleted()
        {
            return await _storeContext.PlaciVideo.Where(placaVideo => placaVideo.Sters == false).ToListAsync();
        }

        public async Task<PlaciVideo> Update(Guid id, PlaciVideo updateObj)
        {
            _storeContext.Entry(updateObj).State = EntityState.Modified;
            await _storeContext.SaveChangesAsync();
            return updateObj;
        }
    }
}
