using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.ProjectHandlers
{
    public class UpdateProjectCommandHandler(IProjectRepository ProjectRepository, IValidator<UpdateProjectCommand> Validator)
        : IRequestHandler<UpdateProjectCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            await Validator.ValidateAndThrowAsync(request, cancellationToken);
            await ProjectRepository.Update(request.ProjectID, request.ProjectName, request.Description, request.Status, cancellationToken);

            return Unit.Value;
        }
    }
}
