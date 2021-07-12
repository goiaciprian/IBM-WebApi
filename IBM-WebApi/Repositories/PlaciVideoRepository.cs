using IBM_WebApi.Interfaces;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Repositories
{
    public class PlaciVideoRepository : DbCrud<PlaciVideo>
    {
        public Task<PlaciVideo> Add(PlaciVideo book)
        {
            throw new NotImplementedException();
        }

        public Task<PlaciVideo> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaciVideo>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<PlaciVideo> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PlaciVideo> Update(Guid id, PlaciVideo book)
        {
            throw new NotImplementedException();
        }
    }
}
