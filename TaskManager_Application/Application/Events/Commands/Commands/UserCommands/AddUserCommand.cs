using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Events.Commands.Commands.UserCommands
{
    public class AddUserCommand : IRequest<Unit>
    {
        public int ProjectId { get; set; }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }

        public AddUserCommand(int projectId, string? fullName, string? email, string? password, Role role)
        {
            ProjectId = projectId;
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        }

        public AddUserCommand()
        {

        }
    }
}
