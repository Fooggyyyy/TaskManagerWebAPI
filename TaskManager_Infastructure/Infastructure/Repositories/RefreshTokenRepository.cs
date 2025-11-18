using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;

namespace TaskManager_Infastructure.Infastructure.Repositories
{
    public class RefreshTokenRepository(AppDBContext dbcontext) : IRefreshTokenRepository
    {
        public async System.Threading.Tasks.Task Add(RefreshToken entity, CancellationToken cancellationToken)
        {
            await dbcontext.RefreshTokens.AddAsync(entity, cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteAll(CancellationToken cancellationToken)
        {
            await dbcontext.RefreshTokens.ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteById(int id, CancellationToken cancellationToken)
        {
            await dbcontext.RefreshTokens.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task<RefreshToken?> FindById(int id, CancellationToken cancellationToken)
        {
            var response = await dbcontext.RefreshTokens.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);

            return response;
        }   

        public async Task<List<RefreshToken>> GetAll(CancellationToken cancellationToken)
        {
            return await dbcontext.RefreshTokens.ToListAsync(cancellationToken);
        }
    }
}
