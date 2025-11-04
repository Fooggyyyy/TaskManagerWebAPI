using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.DataBase.ConfigurationTable;

namespace TaskManager_Infastructure.Infastructure.Repositories
{
    public class CommentRepository(AppDBContext dbcontext) : ICommentRepository
    {
        public async System.Threading.Tasks.Task Add(Comment entity, CancellationToken cancellationToken)
        {
            await dbcontext.Comments.AddAsync(entity, cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteAll(CancellationToken cancellationToken)
        {
            await dbcontext.Comments.ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteById(int id, CancellationToken cancellationToken)
        {
            await dbcontext.Comments.Where(x => x.CommentID == id).ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Comment>> Filter(DateOnly? CommentReleaseDateStart, CancellationToken cancellationToken)
        {
            if(CommentReleaseDateStart == null)
                CommentReleaseDateStart = DateOnly.MinValue;
            return await dbcontext.Comments.Where(x => x.ReleaseDate >= CommentReleaseDateStart).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Comment?> FindById(int id, CancellationToken cancellationToken)
        {
            return await dbcontext.Comments.Where(x => x.CommentID == id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Comment>> GetAll(CancellationToken cancellationToken)
        {
            return await dbcontext.Comments.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task Update(int OldID, string CommmentBody, CancellationToken cancellationToken)
        {
            Comment? comment = await dbcontext.Comments.FirstOrDefaultAsync(c => c.CommentID == OldID, cancellationToken);

            if(comment != null)
            {
                if(CommmentBody != null)
                    comment.CommentBody = CommmentBody;
                dbcontext.Comments.Update(comment);

                await dbcontext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}