using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.LayerCommands
{
    public class DeleteLayerByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        
        public DeleteLayerByIdCommand(int id)
        {
            this.Id = id; 
        }

        public DeleteLayerByIdCommand()
        {

        }
    }
}
