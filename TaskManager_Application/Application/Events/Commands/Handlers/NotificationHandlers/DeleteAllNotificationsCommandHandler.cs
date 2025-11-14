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
    public class DeleteAllNotificationsCommandHandler(INotificationRepository NotificationRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<DeleteAllNotificationsCommand, Unit>
    {
        public Task<Unit> Handle(DeleteAllNotificationsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
