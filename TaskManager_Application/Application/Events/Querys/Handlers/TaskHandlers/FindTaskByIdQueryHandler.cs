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
    public class FindTaskByIdQueryHandler(IProjectRepository ProjectRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<FindTaskByIdQuery, TaskDTO>
    {
        public Task<TaskDTO> Handle(FindTaskByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
