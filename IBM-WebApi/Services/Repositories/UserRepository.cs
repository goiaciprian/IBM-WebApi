using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBM_WebApi.Context;
using IBM_WebApi.Interfaces.IRepositories;
using IBM_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IBM_WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreContext _storeContext;

        public UserRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<User> Add(User newObj)
        {
            newObj.Id_User = Guid.NewGuid();
            await _storeContext.User.AddAsync(newObj);
            return newObj;
        }

        public async Task<User> Delete(Guid id)
        {
            var _deleted = await _storeContext.User.FindAsync(id);
            _deleted.Sters = true;
            _storeContext.Entry(_deleted).State = EntityState.Modified;
            return _deleted;

        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _storeContext.User.ToListAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _storeContext.User.Where(user => user.Id_User == id && user.Sters == false ).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAdminUsers()
        {
            return await _storeContext.User.Where(user => user.Sters == false && user.isAdmin).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetNotDeleted()
        {
            return await _storeContext.User.Where(user => user.Sters == false).ToListAsync();
        }

        public async Task<User> GetOnLogIn(string Email, string Password)
        {
            return await _storeContext.User.Where(user => user.Sters == false && user.Email == Email && user.Parola == Password ).FirstOrDefaultAsync();
        }

        public async Task<User> Update(Guid id, User updateObj)
        {
            await Task.Run(() => _storeContext.Entry(updateObj).State = EntityState.Modified);
            return updateObj;
        }
    }
}
