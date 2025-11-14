using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.NotificationQuerys
{
    public class GetAllNotificationsQuery : IRequest<ICollection<NotificationDTO>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetAllNotificationsQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public GetAllNotificationsQuery() { }
    }
}
