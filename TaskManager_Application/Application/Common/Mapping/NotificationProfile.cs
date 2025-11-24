using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Common.Mapping
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile() 
        {
            CreateMap<Notification, NotificationDTO>().ReverseMap();
            CreateMap<AddNotificationCommand, NotificationDTO>()
                .ForMember(dest => dest.TaskID, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId));
            CreateMap<UpdateNotificationCommand, NotificationDTO>();
        }
    }
}
