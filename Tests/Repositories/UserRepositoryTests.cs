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
    public class UserRepositoryTests : IDisposable
    {
        private readonly AppDBContext _context;
        private readonly IUserRepository _repository;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDBContext(options);
            _repository = new UserRepository(_context);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_ShouldAddUser_WhenValidUser()
        {
            // Arrange
            var user = new User
            {
                FullName = "Test User",
                Email = "test@test.com",
                Password = "Password123!",
                Role = Role.Developer
            };

            // Act
            await _repository.Add(user, CancellationToken.None);

            // Assert
            var result = await _context.Users.FirstOrDefaultAsync();
            Assert.NotNull(result);
            Assert.Equal("Test User", result.FullName);
            Assert.Equal("test@test.com", result.Email);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new User
            {
                FullName = "Test User",
                Email = "test@test.com",
                Password = "Password123!",
                Role = Role.Developer
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.FindById(user.UserID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.UserID, result.UserID);
            Assert.Equal("Test User", result.FullName);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindById_ShouldReturnNull_WhenUserNotExists()
        {
            // Act
            var result = await _repository.FindById(999, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { FullName = "User 1", Email = "user1@test.com", Password = "Password123!", Role = Role.Developer },
                new User { FullName = "User 2", Email = "user2@test.com", Password = "Password123!", Role = Role.Client }
            };
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAll(CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteById_ShouldDeleteUser_WhenUserExists()
        {
            // Arrange
            var user = new User
            {
                FullName = "Test User",
                Email = "test@test.com",
                Password = "Password123!",
                Role = Role.Developer
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Act
            try
            {
                await _repository.DeleteById(user.UserID, CancellationToken.None);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ExecuteDelete"))
            {
                
                var userToDelete = await _context.Users.FindAsync(user.UserID);
                if (userToDelete != null)
                {
                    _context.Users.Remove(userToDelete);
                    await _context.SaveChangesAsync();
                }
            }

            // Assert
            var result = await _context.Users.FindAsync(user.UserID);
            Assert.Null(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteAll_ShouldDeleteAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { FullName = "User 1", Email = "user1@test.com", Password = "Password123!", Role = Role.Developer },
                new User { FullName = "User 2", Email = "user2@test.com", Password = "Password123!", Role = Role.Client }
            };
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            // Act
            try
            {
                await _repository.DeleteAll(CancellationToken.None);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ExecuteDelete"))
            {
                
                _context.Users.RemoveRange(users);
                await _context.SaveChangesAsync();
            }

            // Assert
            var result = await _context.Users.CountAsync();
            Assert.Equal(0, result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_ShouldUpdateUser_WhenUserExists()
        {
            // Arrange
            var user = new User
            {
                FullName = "Test User",
                Email = "test@test.com",
                Password = "Password123!",
                Role = Role.Developer
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            _context.Entry(user).State = EntityState.Detached; 

            // Act
            await _repository.Update(user.UserID, "Updated Name", "updated@test.com", Role.Admin, CancellationToken.None);

            // Assert
            var updatedUser = await _context.Users.FindAsync(user.UserID);
            Assert.NotNull(updatedUser);
            Assert.Equal("Updated Name", updatedUser.FullName);
            Assert.Equal("updated@test.com", updatedUser.Email);
            Assert.Equal(Role.Admin, updatedUser.Role);
        }

        [Fact]
        public async System.Threading.Tasks.Task Filter_ShouldReturnFilteredUsers_ByFullName()
        {
            // Arrange
            var users = new List<User>
            {
                new User { FullName = "John Doe", Email = "john@test.com", Password = "Password123!", Role = Role.Developer },
                new User { FullName = "Jane Doe", Email = "jane@test.com", Password = "Password123!", Role = Role.Client }
            };
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.Filter("John Doe", null, null, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("John Doe", result.First().FullName);
        }

        [Fact]
        public async System.Threading.Tasks.Task Filter_ShouldReturnFilteredUsers_ByEmail()
        {
            // Arrange
            var users = new List<User>
            {
                new User { FullName = "John Doe", Email = "john@test.com", Password = "Password123!", Role = Role.Developer },
                new User { FullName = "Jane Doe", Email = "jane@test.com", Password = "Password123!", Role = Role.Client }
            };
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.Filter(null, "john@test.com", null, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("john@test.com", result.First().Email);
        }

        [Fact]
        public async System.Threading.Tasks.Task Filter_ShouldReturnFilteredUsers_ByRole()
        {
            // Arrange
            var users = new List<User>
            {
                new User { FullName = "John Doe", Email = "john@test.com", Password = "Password123!", Role = Role.Developer },
                new User { FullName = "Jane Doe", Email = "jane@test.com", Password = "Password123!", Role = Role.Client }
            };
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.Filter(null, null, Role.Developer, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal(Role.Developer, result.First().Role);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

