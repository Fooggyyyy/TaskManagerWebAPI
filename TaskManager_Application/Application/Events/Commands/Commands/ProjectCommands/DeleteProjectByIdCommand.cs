using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands
{
    public class DeleteProjectByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteProjectByIdCommand(int id)
        {
            Id = id;
        }

        public DeleteProjectByIdCommand()
        {

        }
    }
}
