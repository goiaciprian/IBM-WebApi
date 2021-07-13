using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Interfaces
{
    public interface DbCrud <T>
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> GetNotDeleted();
        Task<T> Get(Guid id);
        Task<T> Add(T newObj);
        Task<T> Update(Guid id, T updatedObj);
        Task<T> Delete(Guid id);
    }
}
