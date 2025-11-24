using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.ProjectQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.TaskQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.TaskHandlers
{
    public class FilterTasksQueryHandler(ITaskRepository TaskRepository, IMapper Mapper)
        : IRequestHandler<FilterTaskByIdQuery, ICollection<TaskDTO>>
    {
        public async Task<ICollection<TaskDTO>> Handle(FilterTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var FilterTasks = await TaskRepository.Filter(request.TaskName, request.TaskPriority, request.TaskDataStart, request.TaskDataEnd, request.IsComplited, cancellationToken);

            var PagedTasks = FilterTasks.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<TaskDTO>>(PagedTasks);
        }
    }
}
