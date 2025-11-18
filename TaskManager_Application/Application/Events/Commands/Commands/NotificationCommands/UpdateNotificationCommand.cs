using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands
{
    public class UpdateNotificationCommand : IRequest<Unit>
    {
        public int NotificationID { get; set; }

        public string? NotificationName { get; set; }
        public string? NotificationDescription { get; set; }

        public UpdateNotificationCommand(int id, string? notificationame, string? notificationdescription)
        {
            NotificationID = id;
            NotificationName = notificationame;
            NotificationDescription = notificationdescription;
        }

        public UpdateNotificationCommand()
        {

        }
    }
}
