using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.NotificationQuerys
{
    public class FilterNotificationsQuery : IRequest<ICollection<NotificationDTO>>
    {
        public string? NotificationName { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public FilterNotificationsQuery(string? notificationName, int page, int pageSize)
        {
            NotificationName = notificationName;
            Page = page;
            PageSize = pageSize;
        }

        public FilterNotificationsQuery() { }
    }
}
