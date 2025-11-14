using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Events.Querys.Querys.TaskQuerys
{
    public class FilterTasksQuery : IRequest<ICollection<TaskDTO>>
    {
        public string? TaskName { get; set; }
        public Priority TaskPriority { get; set; }
        public DateOnly? TaskDataStart { get; set; }
        public DateOnly? TaskDataEnd { get; set; }
        public bool IsComplited { get; set; }

        public FilterTasksQuery(string? taskName, Priority taskPriority,
            DateOnly? taskDataStart, DateOnly? taskDataEnd, bool isComplited)
        {
            TaskName = taskName;
            TaskPriority = taskPriority;
            TaskDataStart = taskDataStart;
            TaskDataEnd = taskDataEnd;
            IsComplited = isComplited;
        }

        public FilterTasksQuery()
        {

        }
    }
}
