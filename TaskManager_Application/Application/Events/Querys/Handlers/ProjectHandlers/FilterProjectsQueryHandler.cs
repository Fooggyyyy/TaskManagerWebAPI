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
    public class FilterProjectsQueryHandler(IProjectRepository ProjectRepository, IMapper Mapper)
        : IRequestHandler<FilterProjectsQuery, ICollection<ProjectDTO>>
    {
        public async Task<ICollection<ProjectDTO>> Handle(FilterProjectsQuery request, CancellationToken cancellationToken)
        {
            var FilterProjects = await ProjectRepository.Filter(request.ProjectName, request.Status, cancellationToken);

            var PagedProjects = FilterProjects.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<ProjectDTO>>(PagedProjects);
        }
    }
}
