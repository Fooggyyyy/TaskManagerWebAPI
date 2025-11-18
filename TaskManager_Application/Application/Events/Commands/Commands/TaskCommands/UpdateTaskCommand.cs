using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Events.Commands.Commands.TaskCommands
{
    public class UpdateTaskCommand : IRequest<Unit>
    {
        public int TaskID { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public UpdateTaskCommand(int id, string? taskName, string? taskDescription, Priority priority)
        {
            TaskID = id;
            TaskName = taskName;
            Description = taskDescription;
            Priority = priority;
        }

        public UpdateTaskCommand() 
        {

        }
    }
}
