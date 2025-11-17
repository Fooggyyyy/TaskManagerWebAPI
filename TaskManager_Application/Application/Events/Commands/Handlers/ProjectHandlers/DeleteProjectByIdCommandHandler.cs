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
    public class DeleteProjectByIdCommandHandler(IProjectRepository ProjectRepository)
        : IRequestHandler<DeleteProjectByIdCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteProjectByIdCommand request, CancellationToken cancellationToken)
        {
            await ProjectRepository.DeleteById(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
