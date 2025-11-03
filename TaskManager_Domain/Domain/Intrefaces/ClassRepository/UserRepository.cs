using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Intrefaces.ClassRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        System.Threading.Tasks.Task Update(int ID, string? FullName, string? Email, Role? Role, CancellationToken cancellationToken);
        Task<string> ResetPassword(int ID, string OldPassword, string NewPassword, CancellationToken cancellationToken);
        Task<List<User>> Filter(string? UserFullName, string? UserEmail, Role? UserRole, CancellationToken cancellationToken);
    }
}
