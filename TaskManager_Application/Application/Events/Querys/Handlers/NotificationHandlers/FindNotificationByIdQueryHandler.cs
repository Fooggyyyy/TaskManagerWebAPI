using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.NotificationQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.NotificationHandlers
{
    public class FindNotificationByIdQueryHandler(INotificationRepository NotificationRepository, IMapper Mapper)
        : IRequestHandler<FindNotificationByIdQuery, NotificationDTO>
    {
        public async Task<NotificationDTO> Handle(FindNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var Notification = await NotificationRepository.FindById(request.Id, cancellationToken);

            return Mapper.Map<NotificationDTO>(Notification);
        }
    }
}
