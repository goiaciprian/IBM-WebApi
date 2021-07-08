using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_WebApi.Interfaces
{
    public interface DbCrud <T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Add(T book);
        Task<T> Update(int id, T book);
        Task<T> Delete(int id);
    }
}
