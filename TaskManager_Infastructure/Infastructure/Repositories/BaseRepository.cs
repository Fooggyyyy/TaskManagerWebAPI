using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites.FilterAndSort;
using TaskManager_Domain.Domain.Intrefaces;

namespace TaskManager_Infastructure.Infastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Filter(TaskFilterAndSort taskFilter)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Sort(TaskFilterAndSort taskFilter)
        {
            throw new NotImplementedException();
        }
    }
}
