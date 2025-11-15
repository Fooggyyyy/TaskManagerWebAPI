using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.LayerQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.LayerHandlers
{
    public class FilterLayersQueryHandler(ILayerRepository LayerRepository, IMapper Mapper)
        : IRequestHandler<FilterLayersQuery, ICollection<LayerDTO>>
    {
        public async Task<ICollection<LayerDTO>> Handle(FilterLayersQuery request, CancellationToken cancellationToken)
        {
            var LayersFilter = await LayerRepository.Filter(request.LayerName, cancellationToken);

            var PagedLayers = LayersFilter.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<LayerDTO>>(PagedLayers);
        }
    }
}
