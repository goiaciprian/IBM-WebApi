using IBM_WebApi.Interfaces;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Repositories
{
    public class PcsRepository : DbCrud<PCs>
    {
        public Task<PCs> Add(PCs book)
        {
            throw new NotImplementedException();
        }

        public Task<PCs> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PCs>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<PCs> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PCs>> GetNotDeleted()
        {
            throw new NotImplementedException();
        }

        public Task<PCs> Update(Guid id, PCs book)
        {
            throw new NotImplementedException();
        }
    }
}
