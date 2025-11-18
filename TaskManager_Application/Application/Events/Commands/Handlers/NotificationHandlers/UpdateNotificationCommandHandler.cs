using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.NotificationHandlers
{
    public class UpdateNotificationCommandHandler(INotificationRepository NotificationRepository, IMapper Mapper, IValidator<NotificationDTO> Validator)
        : IRequestHandler<UpdateNotificationCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var dto = Mapper.Map<NotificationDTO>(request);

            await Validator.ValidateAndThrowAsync(dto, cancellationToken);
            await NotificationRepository.Update(request.NotificationID, request.NotificationName, request.NotificationDescription, cancellationToken);

            return Unit.Value;
        }
    }
}
