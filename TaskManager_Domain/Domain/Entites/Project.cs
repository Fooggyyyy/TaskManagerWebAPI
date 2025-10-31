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

        public Project(int projectID, string? projectName, string? description, Status status)
        {
            ProjectID = projectID;
            ProjectName = projectName;
            Description = description;
            Status = status;
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
