using IBM_WebApi.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Interfaces.IUnitsOfWork
{
    public interface IUserUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }

        Task<int> Complete();
    }
}
