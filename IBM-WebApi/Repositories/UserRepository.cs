using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBM_WebApi.Interfaces;
using IBM_WebApi.Models;

namespace IBM_WebApi.Repositories
{
    public class UserRepository : DbCrud<User>
    {
        public Task<User> Add(User book)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(Guid id, User book)
        {
            throw new NotImplementedException();
        }
    }
}
