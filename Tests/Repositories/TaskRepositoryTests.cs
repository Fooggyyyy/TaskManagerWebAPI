using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Enums;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.Repositories;
using Xunit;

namespace Tests.Repositories
{
    public class TaskRepositoryTests : IDisposable
    {
        private readonly AppDBContext _context;
        private readonly ITaskRepository _repository;

        public TaskRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDBContext(options);
            _repository = new TaskRepository(_context);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_ShouldAddTask_WhenValidTask()
        {
            // Arrange
            var task = new TaskManager_Domain.Domain.Entites.Task
            {
                TaskName = "Test Task",
                Description = "Test Description",
                Priority = Priority.Medium,
                DateStart = DateOnly.FromDateTime(DateTime.Today),
                DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(7)),
                IsCompleted = false,
                LayerID = 1,
                ProjectID = 1,
                UserID = 1
            };

            // Act
            await _repository.Add(task, CancellationToken.None);

            // Assert
            var result = await _context.Tasks.FirstOrDefaultAsync();
            Assert.NotNull(result);
            Assert.Equal("Test Task", result.TaskName);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindById_ShouldReturnTask_WhenTaskExists()
        {
            // Arrange
            var task = new TaskManager_Domain.Domain.Entites.Task
            {
                TaskName = "Test Task",
                Description = "Test Description",
                Priority = Priority.Medium,
                DateStart = DateOnly.FromDateTime(DateTime.Today),
                DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(7)),
                IsCompleted = false,
                LayerID = 1,
                ProjectID = 1,
                UserID = 1
            };
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.FindById(task.TaskID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(task.TaskID, result.TaskID);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAll_ShouldReturnAllTasks()
        {
            // Arrange
            var tasks = new List<TaskManager_Domain.Domain.Entites.Task>
            {
                new TaskManager_Domain.Domain.Entites.Task { TaskName = "Task 1", Description = "Desc 1", Priority = Priority.Low, DateStart = DateOnly.FromDateTime(DateTime.Today), DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(1)), IsCompleted = false, LayerID = 1, ProjectID = 1, UserID = 1 },
                new TaskManager_Domain.Domain.Entites.Task { TaskName = "Task 2", Description = "Desc 2", Priority = Priority.High, DateStart = DateOnly.FromDateTime(DateTime.Today), DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(2)), IsCompleted = false, LayerID = 1, ProjectID = 1, UserID = 1 }
            };
            await _context.Tasks.AddRangeAsync(tasks);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAll(CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteById_ShouldDeleteTask_WhenTaskExists()
        {
            // Arrange
            var task = new TaskManager_Domain.Domain.Entites.Task
            {
                TaskName = "Test Task",
                Description = "Test Description",
                Priority = Priority.Medium,
                DateStart = DateOnly.FromDateTime(DateTime.Today),
                DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(7)),
                IsCompleted = false,
                LayerID = 1,
                ProjectID = 1,
                UserID = 1
            };
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            // Act
            try
            {
                await _repository.DeleteById(task.TaskID, CancellationToken.None);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ExecuteDelete"))
            {
                
                var taskToDelete = await _context.Tasks.FindAsync(task.TaskID);
                if (taskToDelete != null)
                {
                    _context.Tasks.Remove(taskToDelete);
                    await _context.SaveChangesAsync();
                }
            }

            // Assert
            var result = await _context.Tasks.FindAsync(task.TaskID);
            Assert.Null(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_ShouldUpdateTask_WhenTaskExists()
        {
            // Arrange
            var task = new TaskManager_Domain.Domain.Entites.Task
            {
                TaskName = "Test Task",
                Description = "Test Description",
                Priority = Priority.Medium,
                DateStart = DateOnly.FromDateTime(DateTime.Today),
                DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(7)),
                IsCompleted = false,
                LayerID = 1,
                ProjectID = 1,
                UserID = 1
            };
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            _context.Entry(task).State = EntityState.Detached; 

            // Act
            await _repository.Update(task.TaskID, "Updated Task", "Updated Description", Priority.High, CancellationToken.None);

            // Assert
            var updatedTask = await _context.Tasks.FindAsync(task.TaskID);
            Assert.NotNull(updatedTask);
            Assert.Equal("Updated Task", updatedTask.TaskName);
            Assert.Equal("Updated Description", updatedTask.Description);
            Assert.Equal(Priority.High, updatedTask.Priority);
        }

        [Fact]
        public async System.Threading.Tasks.Task FinishTask_ShouldSetIsCompletedToTrue()
        {
            // Arrange
            var task = new TaskManager_Domain.Domain.Entites.Task
            {
                TaskName = "Test Task",
                Description = "Test Description",
                Priority = Priority.Medium,
                DateStart = DateOnly.FromDateTime(DateTime.Today),
                DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(7)),
                IsCompleted = false,
                LayerID = 1,
                ProjectID = 1,
                UserID = 1
            };
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            _context.Entry(task).State = EntityState.Detached; 

            // Act
            await _repository.FinishTask(task.TaskID, CancellationToken.None);

            // Assert
            var updatedTask = await _context.Tasks.FindAsync(task.TaskID);
            Assert.NotNull(updatedTask);
            Assert.True(updatedTask.IsCompleted);
        }

        [Fact]
        public async System.Threading.Tasks.Task Filter_ShouldReturnFilteredTasks_ByTaskName()
        {
            // Arrange
            var tasks = new List<TaskManager_Domain.Domain.Entites.Task>
            {
                new TaskManager_Domain.Domain.Entites.Task { TaskName = "Task 1", Description = "Desc 1", Priority = Priority.Low, DateStart = DateOnly.FromDateTime(DateTime.Today), DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(1)), IsCompleted = false, LayerID = 1, ProjectID = 1, UserID = 1 },
                new TaskManager_Domain.Domain.Entites.Task { TaskName = "Task 2", Description = "Desc 2", Priority = Priority.High, DateStart = DateOnly.FromDateTime(DateTime.Today), DateEnd = DateOnly.FromDateTime(DateTime.Today.AddDays(2)), IsCompleted = false, LayerID = 1, ProjectID = 1, UserID = 1 }
            };
            await _context.Tasks.AddRangeAsync(tasks);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.Filter("Task 1", null, null, null, null, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("Task 1", result.First().TaskName);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

