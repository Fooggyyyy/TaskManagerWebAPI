using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.LayerCommands
{
    public class UpdateLayerCommand : IRequest<Unit>
    {
        public int LayerID { get; set; }
        public string? LayerName { get; set; }

        public UpdateLayerCommand(int id, string? layerName)
        {
            LayerID = id;
            LayerName = layerName;
        }

        public UpdateLayerCommand()
        {

        }
    }
}
