using IBM_WebApi.Context;
using IBM_WebApi.Interfaces.IRepositories;
using IBM_WebApi.Interfaces.IUnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Services.UnitsOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        public IUserRepository Users { get; }
        private readonly StoreContext _context;

        public UserUnitOfWork(StoreContext context, IUserRepository repo)
        {
            Users = repo;
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
