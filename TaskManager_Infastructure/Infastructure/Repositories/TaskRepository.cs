using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Enums;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.DataBase.ConfigurationTable;

namespace TaskManager_Infastructure.Infastructure.Repositories
{
    public class TaskRepository(AppDBContext dbcontext) : ITaskRepository
    {
        public async System.Threading.Tasks.Task Add(TaskManager_Domain.Domain.Entites.Task entity, CancellationToken cancellationToken)
        {
            await dbcontext.Tasks.AddAsync(entity, cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public System.Threading.Tasks.Task DeleteAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskManager_Domain.Domain.Entites.Task>> Filter(string? TaskName, Priority? TaskPriority, DateOnly? TaskDataStart, DateOnly? TaskDataEnd, bool? TaskIsComplited, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TaskManager_Domain.Domain.Entites.Task> FindById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task FinishTask(int ID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskManager_Domain.Domain.Entites.Task>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Update(int OldID, string? TaskName, string? TaskDescription, Priority? Priority, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}