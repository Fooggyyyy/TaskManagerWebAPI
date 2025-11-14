using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.ProjectHandlers
{
#pragma warning disable CS9113
    public class UpdateProjectCommandHandler(IProjectRepository ProjectRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<UpdateProjectCommand, Unit>
    {
        public Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
