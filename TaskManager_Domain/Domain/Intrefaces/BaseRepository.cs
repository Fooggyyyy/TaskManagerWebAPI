using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Domain.Domain.Intrefaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken);
        Task<T?> FindById(int id, CancellationToken cancellationToken);
        Task Add(T entity, CancellationToken cancellationToken);
        Task DeleteById(int id, CancellationToken cancellationToken);
        Task DeleteAll(CancellationToken cancellationToken);
    }
}
