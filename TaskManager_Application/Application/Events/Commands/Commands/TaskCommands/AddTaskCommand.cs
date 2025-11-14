using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Events.Commands.Commands.TaskCommands
{
    public class AddTaskCommand : IRequest<Unit>
    {
        public int LayerId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }

        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public Priority Priority { get; set; }
        public DateOnly DataStart { get; set; }
        public DateOnly DataEnd { get; set; }

        public AddTaskCommand(int layerId, int projectId, int userId, string? taskName,
            string? taskDescription, Priority priority, DateOnly dataStart, DateOnly dataEnd)
        {
            LayerId = layerId;
            ProjectId = projectId;
            UserId = userId;
            TaskName = taskName;
            TaskDescription = taskDescription;
            Priority = priority;
            DataStart = dataStart;
            DataEnd = dataEnd;
        }

        public AddTaskCommand()
        {

        }
    }
}
