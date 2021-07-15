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
    public class ProcesoareRepository : IProcesoareRepository
    {
        public readonly StoreContext _storeContext;
        public ProcesoareRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<Procesoare> Add(Procesoare newObj)
        {
            newObj.ID_Cpu = Guid.NewGuid();
            await _storeContext.Procesoare.AddAsync(newObj);
            return newObj;
        }

        public async Task<Procesoare> Delete(Guid  id)
        {
            var _deleted = await _storeContext.Procesoare.FindAsync(id);
            _deleted.Sters = true;
            _storeContext.Entry(_deleted).State = EntityState.Modified;
            return _deleted;
        }

        public async Task<IEnumerable<Procesoare>> Get()
        {
            return await _storeContext.Procesoare.ToListAsync();
        }

        public async Task<Procesoare> Get(Guid  id)
        {
            return await _storeContext.Procesoare.Where(procesor => procesor.Sters == false && procesor.ID_Cpu == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Procesoare>> GetNotDeleted()
        {
            return await _storeContext.Procesoare.Where(procesor => procesor.Sters == false).ToListAsync();
        }

        public async Task<Procesoare> Update(Guid  id, Procesoare updateObj)
        {
            _storeContext.Entry(updateObj).State = EntityState.Modified;
            return updateObj;
        }
    }
}
