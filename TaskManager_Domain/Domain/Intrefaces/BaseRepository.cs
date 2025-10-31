using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites.FilterEntities;

namespace TaskManager_Domain.Domain.Intrefaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task Add(T entity);
        Task DeleteById(int id);
        Task DeleteAll();
        Task<List<T>> Filter(TaskFilterAndSort taskFilter);
        Task<List<T>> Sort(TaskFilterAndSort taskFilter);
    }
}
