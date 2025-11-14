using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Events.Querys.Querys.UserQuerys
{
    public class GetAllUsersQuery : IRequest<ICollection<User>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetAllUsersQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public GetAllUsersQuery() { }
    }
}
