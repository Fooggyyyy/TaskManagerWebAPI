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
    public class FindTaskByIdQueryHandler(ITaskRepository TaskRepository, IMapper Mapper)
        : IRequestHandler<FindTaskByIdQuery, TaskDTO>
    {
        public async Task<TaskDTO> Handle(FindTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var Task = await TaskRepository.FindById(request.Id, cancellationToken);

            return Mapper.Map<TaskDTO>(Task);
        }
    }
}
