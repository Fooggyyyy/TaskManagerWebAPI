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
#pragma warning disable CS9113
    public class UpdateTaskCommandHandler(ITaskRepository TaskRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<UpdateTaskCommand, Unit>
    {
        public Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
