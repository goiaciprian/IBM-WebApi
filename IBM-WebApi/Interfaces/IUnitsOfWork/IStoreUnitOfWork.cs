using IBM_WebApi.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Interfaces.IUnitsOfWork
{
    public interface IStoreUnitOfWork: IDisposable
    {
        IRamRepository Rams { get; }
        IPlaciVideoRepository GPUs { get; }
        IProcesoareRepository CPUs { get; }
        IPcsRepository Pcs { get; }

        Task<int> Complete();
    }
}
