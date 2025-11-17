using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.LayerCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.LayerHandlers
{
    public class DeleteAllLayersCommandHandler(ILayerRepository LayerRepository)
        : IRequestHandler<DeleteAllLayersCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAllLayersCommand request, CancellationToken cancellationToken)
        {
            await LayerRepository.DeleteAll(cancellationToken);
            return Unit.Value;
        }
    }
}
