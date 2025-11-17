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
    public class RedirectionToAnotherUserCommandHandler(INotificationRepository NotificationRepository)
        : IRequestHandler<RedirectionToAnotherUserCommand, Unit>
    {
        public async Task<Unit> Handle(RedirectionToAnotherUserCommand request, CancellationToken cancellationToken)
        {
            await NotificationRepository.RedirectionToAnotherUser(request.NotificationId, request.OldUserId, request.NewUserId, cancellationToken);
            return Unit.Value;
        }
    }
}
