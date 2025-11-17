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
            CreateMap<AddTaskCommand, TaskDTO>();
        }
    }
}
