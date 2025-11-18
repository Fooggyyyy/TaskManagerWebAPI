using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands
{
    public class AddProjectCommand : IRequest<Unit>
    {
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }

        public AddProjectCommand(string? projectName, string? prokectDescription, Status status)
        {
            ProjectName = projectName;
            Description = prokectDescription;
            Status = status;
        }

        public AddProjectCommand() 
        {

        }
    }
}
