using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.LayerCommands
{
    public class AddLayerCommand : IRequest<Unit>
    {
        public string? LayerName { get; set; }
        public int ProjectId { get; set; }

        public AddLayerCommand(string? LayerName, int projectId)
        {
            this.LayerName = LayerName;
            ProjectId = projectId;
        }

        public AddLayerCommand() 
        {

        }
    }
}
