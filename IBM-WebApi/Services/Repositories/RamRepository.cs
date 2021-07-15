using IBM_WebApi.Context;
using IBM_WebApi.Interfaces.IRepositories;
using IBM_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Repositories
{
    public class RamRepository : IRamRepository
    {

        private readonly StoreContext _storeContext;

        public RamRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<Ram> Add(Ram newObj)
        {
            newObj.ID_Ram = Guid.NewGuid();
            await _storeContext.Ram.AddAsync(newObj);
            return newObj;
        }

        public async Task<Ram> Delete(Guid  id)
        {
            var _deleted = await _storeContext.Ram.FindAsync(id);
            _deleted.Sters = true;
            _storeContext.Entry(_deleted).State = EntityState.Modified;
            return _deleted;
        }

        public async Task<IEnumerable<Ram>> Get()
        {
            return await _storeContext.Ram.ToListAsync();
        }

        public async Task<Ram> Get(Guid  id)
        {
            return await _storeContext.Ram.Where(ram => ram.Sters == false && ram.ID_Ram == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Ram>> GetNotDeleted()
        {
            return await _storeContext.Ram.Where(ram => ram.Sters == false).ToListAsync();
        }

        public async Task<Ram> Update(Guid id, Ram updateObj)
        {
            _storeContext.Entry(updateObj).State = EntityState.Modified;
            return updateObj;
        }
    }
}
