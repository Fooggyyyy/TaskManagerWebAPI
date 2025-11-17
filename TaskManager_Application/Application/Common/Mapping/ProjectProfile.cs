using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Common.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<AddProjectCommand, ProjectDTO>();
        }
    }
}
