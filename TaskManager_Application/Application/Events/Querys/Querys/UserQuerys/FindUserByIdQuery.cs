using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.UserQuerys
{
    public class FindUserByIdQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }

        public FindUserByIdQuery(int id)
        {
            Id = id;
        }

        public FindUserByIdQuery() { }
    }
}
