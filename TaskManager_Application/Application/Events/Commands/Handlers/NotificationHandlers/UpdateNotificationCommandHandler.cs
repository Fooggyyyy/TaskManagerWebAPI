using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.NotificationHandlers
{
    public class UpdateNotificationCommandHandler(INotificationRepository NotificationRepository, IValidator<UpdateNotificationCommand> Validator)
        : IRequestHandler<UpdateNotificationCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            await Validator.ValidateAndThrowAsync(request, cancellationToken);
            await NotificationRepository.Update(request.NotificationID, request.NotificationName, request.NotificationDescription, cancellationToken);

            return Unit.Value;
        }
    }
}
