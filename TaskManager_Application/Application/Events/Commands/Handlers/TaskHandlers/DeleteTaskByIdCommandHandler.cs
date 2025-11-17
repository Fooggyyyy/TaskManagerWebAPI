using AutoMapper;
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
    public class DeleteTaskByIdCommandHandler(ITaskRepository TaskRepository)
        : IRequestHandler<DeleteTaskByIdCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteTaskByIdCommand request, CancellationToken cancellationToken)
        {
            await TaskRepository.DeleteById(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
