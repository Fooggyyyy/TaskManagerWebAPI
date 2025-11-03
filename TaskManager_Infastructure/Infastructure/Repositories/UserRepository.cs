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
    public class UserRepository(AppDBContext dbcontext) : IUserRepository
    {
        public async System.Threading.Tasks.Task Add(User entity, CancellationToken cancellationToken)
        {
            await dbcontext.Users.AddAsync(entity, cancellationToken);
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

        public Task<List<User>> Filter(string? UserFullName, string? UserEmail, Role? UserRole, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> ResetPassword(int ID, string OldPassword, string NewPassword, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Update(int ID, string? FullName, string? Email, Role? Role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}