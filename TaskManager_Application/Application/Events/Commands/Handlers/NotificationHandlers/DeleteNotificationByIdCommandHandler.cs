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
    public class DeleteNotificationByIdCommandHandler(INotificationRepository NotificationRepository)
        : IRequestHandler<DeleteNotificationByIdCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            await NotificationRepository.DeleteById(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
