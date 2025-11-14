using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.UserCommands
{
    public class DeleteUserByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteUserByIdCommand(int id)
        {
            Id = id;
        }

        public DeleteUserByIdCommand()
        {

        }
    }
}
