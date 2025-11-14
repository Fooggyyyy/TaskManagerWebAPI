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
#pragma warning disable CS9113
    public class GetAllTasksQueryHandler(ITaskRepository TaskRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<GetAllTasksQuery, ICollection<TaskDTO>>
    {
        public Task<ICollection<TaskDTO>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
