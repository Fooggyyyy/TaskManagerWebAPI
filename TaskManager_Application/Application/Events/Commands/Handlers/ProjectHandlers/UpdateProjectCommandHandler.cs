using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.ProjectHandlers
{
    public class UpdateProjectCommandHandler(IProjectRepository ProjectRepository, IMapper Mapper, IValidator<ProjectDTO> Validator)
        : IRequestHandler<UpdateProjectCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var dto = Mapper.Map<ProjectDTO>(request);

            await Validator.ValidateAndThrowAsync(dto, cancellationToken);
            await ProjectRepository.Update(request.ProjectID, request.ProjectName, request.ProjectName, request.Status, cancellationToken);

            return Unit.Value;
        }
    }
}
