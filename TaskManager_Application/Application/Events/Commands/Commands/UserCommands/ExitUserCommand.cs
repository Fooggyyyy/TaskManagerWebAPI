using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.UserCommands
{
    public class ExitUserCommand : IRequest<Unit>
    {
        public string? RefreshToken { get; set; }

        public ExitUserCommand(string? refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public ExitUserCommand() { }
    }
}
