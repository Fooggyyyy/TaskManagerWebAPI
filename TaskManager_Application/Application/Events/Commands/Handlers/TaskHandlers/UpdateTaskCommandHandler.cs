using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.TaskCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.TaskHandlers
{
    public class UpdateTaskCommandHandler(ITaskRepository TaskRepository, IValidator<UpdateTaskCommand> Validator)
        : IRequestHandler<UpdateTaskCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            await Validator.ValidateAndThrowAsync(request, cancellationToken);
            await TaskRepository.Update(request.TaskID, request.TaskName, request.Description, request.Priority, cancellationToken);

            return Unit.Value;
        }
    }
}
