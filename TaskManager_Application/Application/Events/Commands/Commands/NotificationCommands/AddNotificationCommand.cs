using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands
{
    public class AddNotificationCommand : IRequest<Unit>
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }

        public string? NotificationName { get; set; }
        public string? NotificationDescription { get; set; }

        public AddNotificationCommand(int taskId, int userId, string? notificationName, string? notificationDescription)
        {
            TaskId = taskId;
            UserId = userId;
            NotificationName = notificationName;
            NotificationDescription = notificationDescription;
        }

        public AddNotificationCommand()
        {

        }
    }
}
