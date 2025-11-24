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
    public class GetAllNotificationsQueryHandler(INotificationRepository NotificationRepository, IMapper Mapper)
        : IRequestHandler<GetAllNotificationsQuery, ICollection<NotificationDTO>>
    {
        public async Task<ICollection<NotificationDTO>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
        {
            var AllNotification = await NotificationRepository.GetAll(cancellationToken);

            var PagedNotification = AllNotification.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<NotificationDTO>>(PagedNotification);
        }
    }
}
