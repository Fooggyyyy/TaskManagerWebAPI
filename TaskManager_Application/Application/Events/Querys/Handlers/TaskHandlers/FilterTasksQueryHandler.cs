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
#pragma warning disable CS9113
    public class FilterTasksQueryHandler(ITaskRepository TaskRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<FilterTaskByIdQuery, ICollection<TaskDTO>>
    {
        public Task<ICollection<TaskDTO>> Handle(FilterTaskByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
