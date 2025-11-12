using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Common.DTOs
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public bool IsCompleted { get; set; }
        public TaskDTO() 
        {

        }
        public TaskDTO(int taskID, string? taskName, string? description,
            Priority priority, DateOnly dateStart, DateOnly dateEnd, bool isCompleted)
        {
            TaskID = taskID;
            TaskName = taskName;
            Description = description;
            Priority = priority;
            DateStart = dateStart;
            DateEnd = dateEnd;
            IsCompleted = isCompleted;
        }
    }
}
