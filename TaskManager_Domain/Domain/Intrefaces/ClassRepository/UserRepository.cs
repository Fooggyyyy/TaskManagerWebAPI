using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Domain.Domain.Intrefaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
