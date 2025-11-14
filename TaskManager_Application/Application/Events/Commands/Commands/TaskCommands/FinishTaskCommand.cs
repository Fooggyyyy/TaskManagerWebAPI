using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.TaskCommands
{
    public class FinishTaskCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public FinishTaskCommand(int id)
        {
            Id = id;
        }

        public FinishTaskCommand()
        {

        }
    }
}
