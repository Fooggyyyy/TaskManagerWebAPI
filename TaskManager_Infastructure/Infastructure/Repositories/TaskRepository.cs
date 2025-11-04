using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
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

        public async System.Threading.Tasks.Task DeleteAll(CancellationToken cancellationToken)
        {
            await dbcontext.Tasks.ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteById(int id, CancellationToken cancellationToken)
        {
            await dbcontext.Tasks.Where(x => x.TaskID == id).ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TaskManager_Domain.Domain.Entites.Task>> Filter(string? TaskName, Priority? TaskPriority, DateOnly? TaskDataStart, DateOnly? TaskDataEnd, bool? TaskIsComplited, CancellationToken cancellationToken)
        {
            var query = dbcontext.Tasks.AsNoTracking();
            if(TaskDataStart == null)
                TaskDataStart = DateOnly.MinValue;
            if(TaskDataEnd == null)
                TaskDataEnd = DateOnly.MaxValue;

            if(TaskName != null)
                query = query.Where(x => x.TaskName == TaskName);
            if(TaskPriority != null)
                query = query.Where(x => x.Priority == TaskPriority);

            query = query.Where(x => x.DateStart > TaskDataStart &&  x.DateEnd < TaskDataEnd);

            var Tasks = await query.ToListAsync(cancellationToken);

            return Tasks;
        }

        public async Task<TaskManager_Domain.Domain.Entites.Task?> FindById(int id, CancellationToken cancellationToken)
        {
            return await dbcontext.Tasks.Where(x => x.TaskID == id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task FinishTask(int ID, CancellationToken cancellationToken)
        {
            var task = await dbcontext.Tasks.Where(x => x.TaskID == ID).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            if(task != null)
            {
                task.IsCompleted = true;
                dbcontext.Tasks.Update(task);
            }

            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<TaskManager_Domain.Domain.Entites.Task>> GetAll(CancellationToken cancellationToken)
        {
            return await dbcontext.Tasks.ToListAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task Update(int OldID, string? TaskName, string? TaskDescription, Priority? Priority, CancellationToken cancellationToken)
        {
            var task = await dbcontext.Tasks.Where(x => x.TaskID == OldID).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            if (task != null)
            {
                if(TaskName != null)
                    task.TaskName = TaskName;
                if (TaskDescription != null)
                    task.Description = TaskDescription;
                if (Priority != null)
                    task.Priority = Priority.Value;

                dbcontext.Tasks.Update(task);

                await dbcontext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}