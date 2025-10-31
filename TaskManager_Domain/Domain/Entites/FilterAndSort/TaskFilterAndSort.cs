using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Entites.FilterEntities
{
    public class TaskFilterAndSort
    {
        public TaskFilterAndSort() { }

        //For Notifications
        public string? NotificationName { get; set; }

        //For layers
        public string? LayerName { get; set; }

        public TaskFilterAndSort(string? LayerName)
        {
            this.LayerName = LayerName;
        }

        //For projects
        public string? ProjectName { get; set; }
        public Status? ProjectStatus { get; set; }

        public TaskFilterAndSort(string? projectName, Status? projectStatus) : this(projectName)
        {
            ProjectStatus = projectStatus;
        }

        //For Users
        public string? UserFullName { get; set; }
        public string? UserEmail { get; set; }
        public Role? UserRole { get; set; }

        public TaskFilterAndSort(string? userFullName, string? userEmail, Role? userRole) : this(userFullName)
        {
            UserEmail = userEmail;
            UserRole = userRole;
        }

        //For Comments
        public DateOnly? TaskReleaseDate { get; set; }

        public TaskFilterAndSort(DateOnly? taskReleaseDate)
        {
            TaskReleaseDate = taskReleaseDate;
        }

        //For Tasks
        public string? TaskName { get; set; }
        public Priority? TaskPriority { get; set; }
        public DateOnly TaskDataStart { get; set; }
        public DateOnly? TaskDataEnd { get; set; }
        public bool? TaskIsComplited { get ; set; }

        public TaskFilterAndSort(DateOnly? taskReleaseDate, string? taskName, Priority? taskPriority,
            DateOnly taskDataStart, DateOnly? taskDataEnd, bool? taskIsComplited) : this(taskReleaseDate)
        {
            TaskName = taskName;
            TaskPriority = taskPriority;
            TaskDataStart = taskDataStart;
            TaskDataEnd = taskDataEnd;
            TaskIsComplited = taskIsComplited;
        }
    }
}
