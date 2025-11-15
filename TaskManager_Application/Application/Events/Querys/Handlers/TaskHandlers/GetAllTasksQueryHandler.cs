using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.TaskQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.TaskHandlers
{
    public class GetAllTasksQueryHandler(ITaskRepository TaskRepository, IMapper Mapper)
        : IRequestHandler<GetAllTasksQuery, ICollection<TaskDTO>>
    {
        public async Task<ICollection<TaskDTO>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var AllTasks = await TaskRepository.GetAll(cancellationToken);

            var PagedTasks = AllTasks.Take((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<TaskDTO>>(PagedTasks);
        }
    }
}
