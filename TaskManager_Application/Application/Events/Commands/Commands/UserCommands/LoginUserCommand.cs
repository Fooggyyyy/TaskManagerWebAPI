using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<Unit>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public LoginUserCommand(string? email, string? password)
        {
            Email = email;
            Password = password;
        }

        public LoginUserCommand()
        {

        }
    }
}
