using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Common.DTOs
{
    public class NotificationDTO
    {
        public int NotificationID { get; set; }

        public int TaskID { get; set; }
        public int UserID { get; set; }

        public string? NotificationName { get; set; }
        public string? NotificationDescription { get; set; }

        public NotificationDTO()
        {

        }

        public NotificationDTO(int notificationID, string? notificationName, string? notificationDescription, int TaskID, int UserID)
        {
            NotificationID = notificationID;
            NotificationName = notificationName;
            NotificationDescription = notificationDescription;
            this.TaskID = TaskID;
            this.UserID = UserID;
        }
    }
}
