using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.ProjectQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.ProjectHandlers
{
    public class FindProjectByIdQueryHandler(IProjectRepository ProjectRepository, IMapper Mapper)
        : IRequestHandler<FindProjectByIdQuery, ProjectDTO>
    {
        public async Task<ProjectDTO> Handle(FindProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var Project = await ProjectRepository.FindById(request.Id, cancellationToken);

            return Mapper.Map<ProjectDTO>(Project); 
        }
    }
}
