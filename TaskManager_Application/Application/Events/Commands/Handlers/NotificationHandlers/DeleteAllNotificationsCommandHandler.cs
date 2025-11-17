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
    public class DeleteAllNotificationsCommandHandler(INotificationRepository NotificationRepository)
        : IRequestHandler<DeleteAllNotificationsCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAllNotificationsCommand request, CancellationToken cancellationToken)
        {
            await NotificationRepository.DeleteAll(cancellationToken);
            return Unit.Value;
        }
    }
}
