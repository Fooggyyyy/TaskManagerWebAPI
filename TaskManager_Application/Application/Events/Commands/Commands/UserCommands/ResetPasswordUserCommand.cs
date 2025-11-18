using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.UserCommands
{
    public class ResetPasswordUserCommand : IRequest<object>
    {
        public int Id { get; set; }
        
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }

        public ResetPasswordUserCommand(int id, string? oldPassword, string? newPassword)
        {
            Id = id;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }

        public ResetPasswordUserCommand()
        {

        }
    }
}
