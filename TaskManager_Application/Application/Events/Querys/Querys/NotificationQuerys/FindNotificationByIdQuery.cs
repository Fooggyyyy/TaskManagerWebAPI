using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.NotificationQuerys
{
    public class FindNotificationByIdQuery : IRequest<NotificationDTO>
    {
        public int Id { get; set; }

        public FindNotificationByIdQuery(int id)
        {
            Id = id;
        }

        public FindNotificationByIdQuery() { }
    }
}
