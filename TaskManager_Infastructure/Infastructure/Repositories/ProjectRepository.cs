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

        public async System.Threading.Tasks.Task DeleteAll(CancellationToken cancellationToken)
        {
            await dbcontext.Projects.ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteById(int id, CancellationToken cancellationToken)
        {
            await dbcontext.Projects.Where(x => x.ProjectID == id).ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Project>> Filter(string? ProjectName, Status? ProjectStatus, CancellationToken cancellationToken)
        {
            var query = dbcontext.Projects.AsNoTracking();

            if (ProjectName != null)
                query = query.Where(x => x.ProjectName == ProjectName);

            if (ProjectStatus != null)
                query = query.Where(x => x.Status == ProjectStatus);

            var allProjects = await query.ToListAsync(cancellationToken);
            
            return allProjects;
        }

        public async Task<Project?> FindById(int id, CancellationToken cancellationToken)
        {
            return await dbcontext.Projects.Where(x => x.ProjectID == id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Project>> GetAll(CancellationToken cancellationToken)
        {
            return await dbcontext.Projects.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task Update(int OldID, string? ProjectName, string? ProjectDescription, Status? status, CancellationToken cancellationToken)
        {
            Project? project = await dbcontext.Projects.Where(x => x.ProjectID == OldID).FirstOrDefaultAsync(cancellationToken);

            if (project != null)
            {
                if (ProjectName != null)
                    project.ProjectName = ProjectName;

                if (ProjectDescription != null)
                    project.Description = ProjectDescription;

                if (status != null)
                    project.Status = status.Value;

                dbcontext.Projects.Update(project);
                await dbcontext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}