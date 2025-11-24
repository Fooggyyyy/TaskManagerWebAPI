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

        public async System.Threading.Tasks.Task DeleteAll(CancellationToken cancellationToken)
        {
            await dbcontext.Notifications.ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteById(int id, CancellationToken cancellationToken)
        {
            await dbcontext.Notifications.Where(x => x.NotificationID == id).ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Notification>> Filter(string? NotificationName, CancellationToken cancellationToken)
        {
            if (NotificationName == null)
                return await dbcontext.Notifications.AsNoTracking().ToListAsync(cancellationToken);
            return await dbcontext.Notifications.Where(x => x.NotificationName == NotificationName).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Notification?> FindById(int id, CancellationToken cancellationToken)
        {
            return await dbcontext.Notifications.Where(x => x.NotificationID == id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Notification>> GetAll(CancellationToken cancellationToken)
        {
            return await dbcontext.Notifications.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task RedirectionToAnotherUser(int NotificationID, int OldUserID, int NewUserID, CancellationToken cancellationToken)
        {
            Notification? notification = await dbcontext.Notifications
                .Where(x => x.NotificationID == NotificationID && x.UserID == OldUserID).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            if(notification != null)
            {
                notification.UserID = NewUserID;
                dbcontext.Notifications.Update(notification);   
            }

            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task Update(int OldID, string? NotificationName, string? NotificationDescription, CancellationToken cancellationToken)
        {
            Notification? notification = await dbcontext.Notifications
               .Where(x => x.NotificationID == OldID).FirstOrDefaultAsync(cancellationToken);

            if (notification != null)
            {
                if (NotificationName != null)
                    notification.NotificationName = NotificationName;

                if (NotificationDescription != null)
                    notification.NotificationDescription = NotificationDescription;

                dbcontext.Notifications.Update(notification);

                await dbcontext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}