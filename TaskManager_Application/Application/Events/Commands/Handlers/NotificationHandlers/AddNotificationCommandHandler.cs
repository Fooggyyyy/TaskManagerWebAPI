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
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.NotificationHandlers
{
    public class AddNotificationCommandHandler(INotificationRepository NotificationRepository, IMapper Mapper, IValidator<NotificationDTO> Validator)
        : IRequestHandler<AddNotificationCommand, Unit>
    {
        public async Task<Unit> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            var dto = Mapper.Map<NotificationDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<Notification>(dto);

            await NotificationRepository.Add(Result, cancellationToken);

            return Unit.Value;
        }
    }
}
