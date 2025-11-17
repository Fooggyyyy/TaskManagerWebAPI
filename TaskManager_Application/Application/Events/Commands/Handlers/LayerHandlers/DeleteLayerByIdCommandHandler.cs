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
    public class DeleteLayerByIdCommandHandler(ILayerRepository LayerRepository)
        : IRequestHandler<DeleteLayerByIdCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteLayerByIdCommand request, CancellationToken cancellationToken)
        {
            await LayerRepository.DeleteById(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
