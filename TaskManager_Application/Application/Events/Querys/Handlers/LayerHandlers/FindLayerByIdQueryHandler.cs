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
    public class FindLayerByIdQueryHandler(ILayerRepository LayerRepository, IMapper Mapper)
        : IRequestHandler<FindLayerByIdQuery, LayerDTO>
    {
        public async Task<LayerDTO> Handle(FindLayerByIdQuery request, CancellationToken cancellationToken)
        {
            var Layer = await LayerRepository.FindById(request.Id, cancellationToken);

            return Mapper.Map<LayerDTO>(Layer);
        }
    }
}
