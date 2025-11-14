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
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public Priority Priority { get; set; }
        public DateOnly DataStart { get; set; }
        public DateOnly DataEnd { get; set; }

        public UpdateTaskCommand(string? taskName, string? taskDescription, Priority priority,
            DateOnly dataStart, DateOnly dataEnd)
        {
            TaskName = taskName;
            TaskDescription = taskDescription;
            Priority = priority;
            DataStart = dataStart;
            DataEnd = dataEnd;
        }

        public UpdateTaskCommand() 
        {

        }
    }
}
