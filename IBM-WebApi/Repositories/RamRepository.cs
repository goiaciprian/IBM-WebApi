using IBM_WebApi.Interfaces;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Repositories
{
    public class RamRepository : DbCrud<Ram>
    {
        public Task<Ram> Add(Ram book)
        {
            throw new NotImplementedException();
        }

        public Task<Ram> Delete(Guid  id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ram>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Ram> Get(Guid  id)
        {
            throw new NotImplementedException();
        }

        public Task<Ram> Update(Guid id, Ram book)
        {
            throw new NotImplementedException();
        }
    }
}
