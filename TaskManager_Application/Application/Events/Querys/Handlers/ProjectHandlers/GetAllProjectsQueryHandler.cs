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
    public class GetAllProjectsQueryHandler(IProjectRepository ProjectRepository, IMapper Mapper)
        : IRequestHandler<GetAllProjectsQuery, ICollection<ProjectDTO>>
    {
        public async Task<ICollection<ProjectDTO>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var AllProjects = await ProjectRepository.GetAll(cancellationToken);

            var PagedProjects = AllProjects.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<ProjectDTO>>(PagedProjects);
        }
    }
}
