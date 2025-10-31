using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Entites
{
    public class Task
    {
        public int TaskID { get; set; }

        public int LayerID { get; set; }
        public Layer? Layer { get; set; }

        public int ProjectID { get; set; }
        public Project? Project { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        public string? TaskName { get; set; }   
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int taskID, int layerID, Layer? layer, int projectID,
            Project? project, int userID, User? user, string? taskName, string? description,
            Priority priority, DateOnly dateStart, DateOnly dateEnd, bool isCompleted)
        {
            TaskID = taskID;
            LayerID = layerID;
            Layer = layer;
            ProjectID = projectID;
            Project = project;
            UserID = userID;
            User = user;
            TaskName = taskName;
            Description = description;
            Priority = priority;
            DateStart = dateStart;
            DateEnd = dateEnd;
            IsCompleted = isCompleted;
        }

        public Task(int taskID, int layerID, int projectID, int userID, string? taskName,
            string? description, Priority priority, DateOnly dateStart, DateOnly dateEnd, bool isCompleted)
        {
            TaskID = taskID;
            LayerID = layerID;
            ProjectID = projectID;
            UserID = userID;
            TaskName = taskName;
            Description = description;
            Priority = priority;
            DateStart = dateStart;
            DateEnd = dateEnd;
            IsCompleted = isCompleted;
        }

        public Task(int taskID, int layerID, int projectID, int userID, string? taskName,
            string? description, Priority priority, DateOnly dateStart, DateOnly dateEnd)
        {
            TaskID = taskID;
            LayerID = layerID;
            ProjectID = projectID;
            UserID = userID;
            TaskName = taskName;
            Description = description;
            Priority = priority;
            DateStart = dateStart;
            DateEnd = dateEnd;
            IsCompleted = false;
        }

        public Task()
        {
        }
    }
}
