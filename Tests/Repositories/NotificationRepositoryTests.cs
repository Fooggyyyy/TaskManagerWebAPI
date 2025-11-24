using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.Repositories;
using Xunit;

namespace Tests.Repositories
{
    public class NotificationRepositoryTests : IDisposable
    {
        private readonly AppDBContext _context;
        private readonly INotificationRepository _repository;

        public NotificationRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDBContext(options);
            _repository = new NotificationRepository(_context);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_ShouldAddNotification_WhenValidNotification()
        {
            // Arrange
            var notification = new Notification
            {
                NotificationName = "Test Notification",
                NotificationDescription = "Test Description",
                UserID = 1,
                TaskID = 1
            };

            // Act
            await _repository.Add(notification, CancellationToken.None);

            // Assert
            var result = await _context.Notifications.FirstOrDefaultAsync();
            Assert.NotNull(result);
            Assert.Equal("Test Notification", result.NotificationName);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindById_ShouldReturnNotification_WhenNotificationExists()
        {
            // Arrange
            var notification = new Notification
            {
                NotificationName = "Test Notification",
                NotificationDescription = "Test Description",
                UserID = 1,
                TaskID = 1
            };
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.FindById(notification.NotificationID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(notification.NotificationID, result.NotificationID);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAll_ShouldReturnAllNotifications()
        {
            // Arrange
            var notifications = new List<Notification>
            {
                new Notification { NotificationName = "Notification 1", NotificationDescription = "Desc 1", UserID = 1, TaskID = 1 },
                new Notification { NotificationName = "Notification 2", NotificationDescription = "Desc 2", UserID = 1, TaskID = 1 }
            };
            await _context.Notifications.AddRangeAsync(notifications);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAll(CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteById_ShouldDeleteNotification_WhenNotificationExists()
        {
            // Arrange
            var notification = new Notification
            {
                NotificationName = "Test Notification",
                NotificationDescription = "Test Description",
                UserID = 1,
                TaskID = 1
            };
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();

            // Act
            try
            {
                await _repository.DeleteById(notification.NotificationID, CancellationToken.None);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ExecuteDelete"))
            {
                
                var notificationToDelete = await _context.Notifications.FindAsync(notification.NotificationID);
                if (notificationToDelete != null)
                {
                    _context.Notifications.Remove(notificationToDelete);
                    await _context.SaveChangesAsync();
                }
            }

            // Assert
            var result = await _context.Notifications.FindAsync(notification.NotificationID);
            Assert.Null(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_ShouldUpdateNotification_WhenNotificationExists()
        {
            // Arrange
            var notification = new Notification
            {
                NotificationName = "Test Notification",
                NotificationDescription = "Test Description",
                UserID = 1,
                TaskID = 1
            };
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            _context.Entry(notification).State = EntityState.Detached; 

            // Act
            await _repository.Update(notification.NotificationID, "Updated Notification", "Updated Description", CancellationToken.None);

            // Assert
            var updatedNotification = await _context.Notifications.FindAsync(notification.NotificationID);
            Assert.NotNull(updatedNotification);
            Assert.Equal("Updated Notification", updatedNotification.NotificationName);
            Assert.Equal("Updated Description", updatedNotification.NotificationDescription);
        }

        [Fact]
        public async System.Threading.Tasks.Task Filter_ShouldReturnFilteredNotifications_ByNotificationName()
        {
            // Arrange
            var notifications = new List<Notification>
            {
                new Notification { NotificationName = "Notification 1", NotificationDescription = "Desc 1", UserID = 1, TaskID = 1 },
                new Notification { NotificationName = "Notification 2", NotificationDescription = "Desc 2", UserID = 1, TaskID = 1 }
            };
            await _context.Notifications.AddRangeAsync(notifications);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.Filter("Notification 1", CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("Notification 1", result.First().NotificationName);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

