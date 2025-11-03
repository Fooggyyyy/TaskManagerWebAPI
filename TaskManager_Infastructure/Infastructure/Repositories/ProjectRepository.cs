using Microsoft.EntityFrameworkCore;
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
    public class ProjectRepository(AppDBContext dbcontext) : IProjectRepository
    {
        public async System.Threading.Tasks.Task Add(Project entity, CancellationToken cancellationToken)
        {
            await dbcontext.Projects.AddAsync(entity, cancellationToken);
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

        public Task<List<Project>> Filter(string? ProjectName, Status? ProjectStatus, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Project> FindById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Update(int OldID, string? ProjectName, string? ProjectDescription, Status? status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}