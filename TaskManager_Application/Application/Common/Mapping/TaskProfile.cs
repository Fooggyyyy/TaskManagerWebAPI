using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.TaskCommands;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Common.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile() 
        {
            CreateMap<TaskManager_Domain.Domain.Entites.Task, TaskDTO>().ReverseMap();
            CreateMap<AddTaskCommand, TaskDTO>()
                .ForMember(dest => dest.LayerID, opt => opt.MapFrom(src => src.LayerId))
                .ForMember(dest => dest.ProjectID, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.TaskName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.TaskDescription))
                .ForMember(dest => dest.DateStart, opt => opt.MapFrom(src => src.DataStart))
                .ForMember(dest => dest.DateEnd, opt => opt.MapFrom(src => src.DataEnd));
            CreateMap<UpdateTaskCommand, TaskDTO>();
        }
    }
}
