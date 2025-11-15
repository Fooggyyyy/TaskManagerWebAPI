using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.LayerQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.LayerHandlers
{
    public class GetAllLayersQueryHandler(ILayerRepository LayerRepository, IMapper Mapper)
        : IRequestHandler<GetAllLayersQuery, ICollection<LayerDTO>>
    {
        public async Task<ICollection<LayerDTO>> Handle(GetAllLayersQuery request, CancellationToken cancellationToken)
        {
            var AllLayers = await LayerRepository.GetAll(cancellationToken);

            var PagedLayers = AllLayers.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<LayerDTO>>(PagedLayers);
        }
    }
}
