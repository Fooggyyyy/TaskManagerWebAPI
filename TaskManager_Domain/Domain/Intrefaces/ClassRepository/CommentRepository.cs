using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Domain.Domain.Intrefaces.ClassRepository
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        System.Threading.Tasks.Task Update(int OldID, string CommmentBody, CancellationToken cancellationToken);
        Task<List<Comment>> Filter(DateOnly? CommentReleaseDateStart, CancellationToken cancellationToken);
    }
}
