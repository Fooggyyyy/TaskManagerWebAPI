using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.NotificationHandlers
{
#pragma warning disable CS9113
    public class UpdateNotificationCommandHandler(INotificationRepository NotificationRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<UpdateNotificationCommand, Unit>
    {
        public Task<Unit> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
