using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands
{
    public class RedirectionToAnotherUserCommand : IRequest<Unit>
    {
        public int NotificationId { get; set; }

        public int OldUserId { get; set; }
        public int NewUserId { get; set; }

        public RedirectionToAnotherUserCommand(int notificationId, int oldUserId, int newUserId)
        {
            NotificationId = notificationId;
            OldUserId = oldUserId;
            NewUserId = newUserId;
        }

        public RedirectionToAnotherUserCommand() 
        {

        }
    }
}
