using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Common.Mapping
{
    public class LayerProfile : Profile
    {
        public LayerProfile() 
        {
            CreateMap<Layer, LayerDTO>().ReverseMap();
        }
    }
}
