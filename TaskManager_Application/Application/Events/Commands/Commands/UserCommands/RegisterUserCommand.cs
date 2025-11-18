using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.UserCommands
{
    public class RegisterUserCommand : IRequest<object>
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public RegisterUserCommand(string? fullName, string? email, string? password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public RegisterUserCommand()
        {

        }
    }
}
