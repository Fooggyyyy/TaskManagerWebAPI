using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Intrefaces.ClassRepository
{
    public interface ILayerRepository : IBaseRepository<Layer>
    {
        System.Threading.Tasks.Task Update(int OldID, string LayerName, CancellationToken cancellationToken);
        Task<List<Layer>> Filter(string? LayerName, CancellationToken cancellationToken);
    }
}
