using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.LayerQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.NotificationQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.NotificationHandlers
{
    public class FilterNotificationsQueryHandler(INotificationRepository NotificationRepository, IMapper Mapper)
        : IRequestHandler<FilterNotificationsQuery, ICollection<NotificationDTO>>
    {
        public async Task<ICollection<NotificationDTO>> Handle(FilterNotificationsQuery request, CancellationToken cancellationToken)
        {
            var FilterNotification = await NotificationRepository.Filter(request.NotificationName, cancellationToken);

            var PagedNotification = FilterNotification.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<NotificationDTO>>(PagedNotification);
        }
    }
}
