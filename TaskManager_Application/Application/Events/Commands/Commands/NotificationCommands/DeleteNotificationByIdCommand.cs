using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands
{
    public class DeleteNotificationByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteNotificationByIdCommand(int id)
        {
            Id = id;
        }

        public DeleteNotificationByIdCommand()
        {

        }
    }
}
