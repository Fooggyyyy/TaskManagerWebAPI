using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Domain.Domain.Intrefaces.ClassRepository
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        System.Threading.Tasks.Task Update(int OldID, string? NotificationName, string? NotificationDescription);
        System.Threading.Tasks.Task RedirectionToAnotherUser(int OldUserID, int NewUserID);
    }
}
