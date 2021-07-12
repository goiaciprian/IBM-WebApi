using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Interfaces
{
    public interface DbCrud <T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(Guid id);
        Task<T> Add(T book);
        Task<T> Update(Guid id, T book);
        Task<T> Delete(Guid id);
    }
}
