using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Intrefaces.ClassRepository
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        System.Threading.Tasks.Task Update(int OldID, string? NotificationName, string? NotificationDescriptionm, CancellationToken cancellationToken);
        System.Threading.Tasks.Task RedirectionToAnotherUser(int OldUserID, int NewUserID, CancellationToken cancellationToken);
        Task<List<Notification>> Filter(string? NotificationName, CancellationToken cancellationToken);
    }
}
