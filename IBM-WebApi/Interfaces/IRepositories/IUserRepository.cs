using IBM_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Interfaces.IRepositories
{
    public interface IUserRepository: IDbCrud<User>
    {
        public Task<User> GetOnLogIn(string Email, string Password);
        public Task<IEnumerable<User>> GetAdminUsers();
    }
}
