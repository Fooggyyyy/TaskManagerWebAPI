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
    public class DeleteNotificationByIdCommandHandler(INotificationRepository NotificationRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<DeleteNotificationByIdCommand, Unit>
    {
        public Task<Unit> Handle(DeleteNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
