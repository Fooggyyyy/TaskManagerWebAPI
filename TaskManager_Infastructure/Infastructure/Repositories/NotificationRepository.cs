using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.DataBase.ConfigurationTable;

namespace TaskManager_Infastructure.Infastructure.Repositories
{
    public class NotificationRepository(AppDBContext dbcontext) : INotificationRepository
    {
        public async System.Threading.Tasks.Task Add(Notification entity, CancellationToken cancellationToken)
        {
            await dbcontext.Notifications.AddAsync(entity, cancellationToken);
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

        public Task<List<Notification>> Filter(string? NotificationName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> FindById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Notification>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task RedirectionToAnotherUser(int OldUserID, int NewUserID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Update(int OldID, string? NotificationName, string? NotificationDescriptionm, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}