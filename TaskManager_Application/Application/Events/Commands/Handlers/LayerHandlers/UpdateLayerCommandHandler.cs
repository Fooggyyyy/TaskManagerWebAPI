using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.LayerCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.LayerHandlers
{
    public class UpdateLayerCommandHandler(ILayerRepository LayerRepository, IValidator<UpdateLayerCommand> Validator)
        : IRequestHandler<UpdateLayerCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateLayerCommand request, CancellationToken cancellationToken)
        {
            await Validator.ValidateAndThrowAsync(request, cancellationToken);
            await LayerRepository.Update(request.LayerID, request.LayerName ?? string.Empty, cancellationToken);

            return Unit.Value;
        }
    }
}
