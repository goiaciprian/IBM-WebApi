using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Interfaces
{
    public interface IDbCrud <T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> GetNotDeleted();
        Task<T> Get(Guid id);
        Task<T> Add(T newObj);
        Task<T> Update(Guid id, T updatedObj);
        Task<T> Delete(Guid id);
    }
}
