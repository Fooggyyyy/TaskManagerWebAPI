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
    public class DeleteAllProjectsCommandHandler(IProjectRepository ProjectRepository)
        : IRequestHandler<DeleteAllProjectsCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAllProjectsCommand request, CancellationToken cancellationToken)
        {
            await ProjectRepository.DeleteAll(cancellationToken);
            return Unit.Value;
        }
    }
}
