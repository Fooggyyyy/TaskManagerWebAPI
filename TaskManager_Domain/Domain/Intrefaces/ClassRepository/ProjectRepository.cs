using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Intrefaces.ClassRepository
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        System.Threading.Tasks.Task Update(int OldID, string? ProjectName, string? ProjectDescription, Status? status, CancellationToken cancellationToken);
        Task<List<Project>> Filter(string? ProjectName, Status? ProjectStatus, CancellationToken cancellationToken);
    }
}
