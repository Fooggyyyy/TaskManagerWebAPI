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
    public class LayerRepository(AppDBContext dbcontext) : ILayerRepository
    {
        public async System.Threading.Tasks.Task Add(Layer entity, CancellationToken cancellationToken)
        {
            await dbcontext.Layers.AddAsync(entity, cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteAll(CancellationToken cancellationToken)
        {
            await dbcontext.Layers.ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteById(int id, CancellationToken cancellationToken)
        {
            await dbcontext.Layers.Where(x => x.LayerID == id).ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public Task<List<Layer>> Filter(string? LayerName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Layer> FindById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Layer>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Update(int OldID, string LayerName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}