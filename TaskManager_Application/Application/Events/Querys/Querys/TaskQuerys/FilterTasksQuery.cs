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
    public class FilterTaskByIdQuery : IRequest<ICollection<TaskDTO>>
    {
        public string? TaskName { get; set; }
        public Priority TaskPriority { get; set; }
        public DateOnly? TaskDataStart { get; set; }
        public DateOnly? TaskDataEnd { get; set; }
        public bool IsComplited { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }

        public FilterTaskByIdQuery(string? taskName, Priority taskPriority, DateOnly? taskDataStart, DateOnly? taskDataEnd, bool isComplited, int page, int pageSize)
        {
            TaskName = taskName;
            TaskPriority = taskPriority;
            TaskDataStart = taskDataStart;
            TaskDataEnd = taskDataEnd;
            IsComplited = isComplited;
            Page = page;
            PageSize = pageSize;
        }

        public FilterTaskByIdQuery()
        {

        }
    }
}
