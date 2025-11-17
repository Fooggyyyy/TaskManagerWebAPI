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
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.ProjectHandlers
{
    public class AddProjectCommandHandler(IProjectRepository ProjectRepository, IMapper Mapper, IValidator<ProjectDTO> Validator)
        : IRequestHandler<AddProjectCommand, Unit>
    {
        public async Task<Unit> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var dto = Mapper.Map<ProjectDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<Project>(dto);

            await ProjectRepository.Add(Result, cancellationToken);

            return Unit.Value;
        }
    }
}
