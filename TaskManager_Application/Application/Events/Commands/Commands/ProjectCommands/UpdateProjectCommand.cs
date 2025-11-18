using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public int ProjectID { get; set; }

        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }

        public UpdateProjectCommand(int id, string? projectName, string? prokectDescription, Status status)
        {
            ProjectID = id;
            ProjectName = projectName;
            Description = prokectDescription;
            Status = status;
        }

        public UpdateProjectCommand()
        {

        }
    }
}
