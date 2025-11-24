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

        public async System.Threading.Tasks.Task DeleteAll(CancellationToken cancellationToken)
        {
            await dbcontext.Users.ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task DeleteById(int id, CancellationToken cancellationToken)
        {
            await dbcontext.Users.Where(x => x.UserID == id).ExecuteDeleteAsync(cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<User>> Filter(string? UserFullName, string? UserEmail, Role? UserRole, CancellationToken cancellationToken)
        {
            var query = dbcontext.Users.AsNoTracking();

            if(UserFullName != null)
                query = query.Where(x => x.FullName == UserFullName);
            if(UserEmail != null)
                query = query.Where(x => x.Email == UserEmail);
            if(UserRole != null)
                query = query.Where(x => x.Role == UserRole);

            var Users = await query.ToListAsync(cancellationToken);

            return Users;
        }

        public async Task<User?> FindById(int id, CancellationToken cancellationToken)
        {
            return await dbcontext.Users.Where(x => x.UserID == id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            return await dbcontext.Users.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async System.Threading.Tasks.Task ResetPassword(int ID, string OldPassword, string NewPassword, CancellationToken cancellationToken)
        {
            var user = await dbcontext.Users.Where(x => x.UserID == ID && x.Password == OldPassword).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            if(user != null)
            {
                user.Password = NewPassword;
                dbcontext.Users.Update(user);
                await dbcontext.SaveChangesAsync(cancellationToken);
            }
        }

        public async System.Threading.Tasks.Task Update(int ID, string? FullName, string? Email, Role? Role, CancellationToken cancellationToken)
        {
            var user = await dbcontext.Users.Where(x => x.UserID == ID).FirstOrDefaultAsync(cancellationToken);

            if(user != null)
            {
                if(FullName !=  null) 
                    user.FullName = FullName;
                if(Email != null) 
                    user.Email = Email;
                if (Role != null)
                    user.Role = Role.Value;

                dbcontext.Users.Update(user);
                await dbcontext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}