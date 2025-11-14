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
#pragma warning disable CS9113
    public class GetAllProjectsQueryHandler(IProjectRepository ProjectRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<GetAllProjectsQuery, ICollection<ProjectDTO>>
    {
        public Task<ICollection<ProjectDTO>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
