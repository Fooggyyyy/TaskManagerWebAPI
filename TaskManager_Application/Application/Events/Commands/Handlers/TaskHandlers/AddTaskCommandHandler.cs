using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.TaskCommands;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.TaskHandlers
{
    public class AddTaskCommandHandler(ITaskRepository TaskRepository, IMapper Mapper, IValidator<TaskDTO> Validator)
        : IRequestHandler<AddTaskCommand, Unit>
    {
        public async Task<Unit> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var dto = Mapper.Map<TaskDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<TaskManager_Domain.Domain.Entites.Task>(dto);

            await TaskRepository.Add(Result, cancellationToken);

            return Unit.Value;
        }
    }
}
