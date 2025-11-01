using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Intrefaces.ClassRepository
{
    public interface ITaskRepository : IBaseRepository<TaskManager_Domain.Domain.Entites.Task>
    {
        System.Threading.Tasks.Task Update(int OldID, string? TaskName, string? TaskDescription, Priority? Priority);
        System.Threading.Tasks.Task FinishTask(int ID);
    }
}
