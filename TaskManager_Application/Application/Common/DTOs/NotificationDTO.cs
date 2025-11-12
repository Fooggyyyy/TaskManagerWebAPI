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
        public string? NotificationName { get; set; }
        public string? NotificationDescription { get; set; }

        public NotificationDTO()
        {

        }

        public NotificationDTO(int notificationID, string? notificationName, string? notificationDescription)
        {
            NotificationID = notificationID;
            NotificationName = notificationName;
            NotificationDescription = notificationDescription;
        }
    }
}
