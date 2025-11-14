using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Events.Querys.Querys.UserQuerys
{
    public class FilterUsersQuery : IRequest<ICollection<UserDTO>>
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }

        public FilterUsersQuery(string? fullName, string? email, Role role)
        {
            FullName = fullName;
            Email = email;
            Role = role;
        }

        public FilterUsersQuery()
        {

        }
    }
}
