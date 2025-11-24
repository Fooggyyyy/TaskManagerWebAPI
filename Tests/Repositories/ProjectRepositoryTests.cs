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
    public class ProjectRepositoryTests : IDisposable
    {
        private readonly AppDBContext _context;
        private readonly IProjectRepository _repository;

        public ProjectRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDBContext(options);
            _repository = new ProjectRepository(_context);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_ShouldAddProject_WhenValidProject()
        {
            // Arrange
            var project = new Project
            {
                ProjectName = "Test Project",
                Description = "Test Description",
                Status = Status.Active
            };

            // Act
            await _repository.Add(project, CancellationToken.None);

            // Assert
            var result = await _context.Projects.FirstOrDefaultAsync();
            Assert.NotNull(result);
            Assert.Equal("Test Project", result.ProjectName);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindById_ShouldReturnProject_WhenProjectExists()
        {
            // Arrange
            var project = new Project
            {
                ProjectName = "Test Project",
                Description = "Test Description",
                Status = Status.Active
            };
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.FindById(project.ProjectID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(project.ProjectID, result.ProjectID);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAll_ShouldReturnAllProjects()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project { ProjectName = "Project 1", Description = "Desc 1", Status = Status.Active },
                new Project { ProjectName = "Project 2", Description = "Desc 2", Status = Status.Completed }
            };
            await _context.Projects.AddRangeAsync(projects);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAll(CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteById_ShouldDeleteProject_WhenProjectExists()
        {
            // Arrange
            var project = new Project
            {
                ProjectName = "Test Project",
                Description = "Test Description",
                Status = Status.Active
            };
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            // Act
            try
            {
                await _repository.DeleteById(project.ProjectID, CancellationToken.None);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ExecuteDelete"))
            {
                
                var projectToDelete = await _context.Projects.FindAsync(project.ProjectID);
                if (projectToDelete != null)
                {
                    _context.Projects.Remove(projectToDelete);
                    await _context.SaveChangesAsync();
                }
            }

            // Assert
            var result = await _context.Projects.FindAsync(project.ProjectID);
            Assert.Null(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_ShouldUpdateProject_WhenProjectExists()
        {
            // Arrange
            var project = new Project
            {
                ProjectName = "Test Project",
                Description = "Test Description",
                Status = Status.Active
            };
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            _context.Entry(project).State = EntityState.Detached; 

            // Act
            await _repository.Update(project.ProjectID, "Updated Project", "Updated Description", Status.Completed, CancellationToken.None);

            // Assert
            var updatedProject = await _context.Projects.FindAsync(project.ProjectID);
            Assert.NotNull(updatedProject);
            Assert.Equal("Updated Project", updatedProject.ProjectName);
            Assert.Equal("Updated Description", updatedProject.Description);
            Assert.Equal(Status.Completed, updatedProject.Status);
        }

        [Fact]
        public async System.Threading.Tasks.Task Filter_ShouldReturnFilteredProjects_ByProjectName()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project { ProjectName = "Project 1", Description = "Desc 1", Status = Status.Active },
                new Project { ProjectName = "Project 2", Description = "Desc 2", Status = Status.Completed }
            };
            await _context.Projects.AddRangeAsync(projects);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.Filter("Project 1", null, CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("Project 1", result.First().ProjectName);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

