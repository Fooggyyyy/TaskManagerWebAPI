using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Entites
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public virtual List<TaskManager_Domain.Domain.Entites.Task> Tasks { get; set; } = null!;
        public virtual List<Layer> Layers { get; set; } = null!;
        public virtual List<User> Users { get; set; } = null!;
        public Project(int projectID, string? projectName, string? description, Status status,
            List<TaskManager_Domain.Domain.Entites.Task> tasks, List<Layer> layers, List<User> users)
        {
            ProjectID = projectID;
            ProjectName = projectName;
            Description = description;
            Status = status;
            Tasks = tasks;
            Layers = layers;
            Users = users;
        }

        public Project(int projectID, string? projectName, string? description)
        {
            ProjectID = projectID;
            ProjectName = projectName;
            Description = description;
            Status = 0;
        }

        public Project() 
        { 
        }
    }
}
