using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Domain.Domain.Entites
{
    public class Notification
    {
        public int NotificationID { get; set; }

        public int TaskID { get; set; }
        public Task? Task { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        public string? NotificationName { get; set; }
        public string? NotificationDescription { get; set; }

        public Notification(int notificationID, int taskID, Task? task, int userID,
            User? user, string? notificationName, string? notificationDescription)
        {
            NotificationID = notificationID;
            TaskID = taskID;
            Task = task;
            UserID = userID;
            User = user;
            NotificationName = notificationName;
            NotificationDescription = notificationDescription;
        }

        public Notification(int notificationID, int taskID, int userID, string? notificationName,
            string? notificationDescription)
        {
            NotificationID = notificationID;
            TaskID = taskID;
            UserID = userID;
            NotificationName = notificationName;
            NotificationDescription = notificationDescription;
        }

        public Notification()
        {
        }
    }
}
