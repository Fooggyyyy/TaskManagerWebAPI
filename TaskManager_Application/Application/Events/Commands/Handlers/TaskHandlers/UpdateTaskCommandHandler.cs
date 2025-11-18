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
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.TaskHandlers
{
    public class UpdateTaskCommandHandler(ITaskRepository TaskRepository, IMapper Mapper, IValidator<TaskDTO> Validator)
        : IRequestHandler<UpdateTaskCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var dto = Mapper.Map<TaskDTO>(request);

            await Validator.ValidateAndThrowAsync(dto, cancellationToken);
            await TaskRepository.Update(request.TaskID, request.TaskName, request.Description, request.Priority, cancellationToken);

            return Unit.Value;
        }
    }
}
