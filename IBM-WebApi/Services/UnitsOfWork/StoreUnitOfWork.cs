using IBM_WebApi.Context;
using IBM_WebApi.Interfaces.IRepositories;
using IBM_WebApi.Interfaces.IUnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Services.UnitsOfWork
{
    public class StoreUnitOfWork : IStoreUnitOfWork
    {
        public IRamRepository Rams { get; }

        public IPlaciVideoRepository GPUs { get; }

        public IProcesoareRepository CPUs { get; }

        public IPcsRepository Pcs { get; }

        private readonly StoreContext _context;

        public StoreUnitOfWork(IRamRepository rams,IPlaciVideoRepository gpus, IProcesoareRepository cpus, 
            IPcsRepository pcs, StoreContext context)
        {
            Rams = rams;
            GPUs = gpus;
            CPUs = cpus;
            Pcs = pcs;
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
