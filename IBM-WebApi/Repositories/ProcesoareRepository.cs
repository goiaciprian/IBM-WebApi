using IBM_WebApi.Interfaces;
using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Repositories
{
    public class ProcesoareRepository : DbCrud<Procesoare>
    {
        public Task<Procesoare> Add(Procesoare book)
        {
            throw new NotImplementedException();
        }

        public Task<Procesoare> Delete(Guid  id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Procesoare>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Procesoare> Get(Guid  id)
        {
            throw new NotImplementedException();
        }

        public Task<Procesoare> Update(Guid  id, Procesoare book)
        {
            throw new NotImplementedException();
        }
    }
}
