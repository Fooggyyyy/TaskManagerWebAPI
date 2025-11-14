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
#pragma warning disable CS9113
    public class FindLayerByIdQueryHandler(ILayerRepository LayerRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<FindLayerByIdQuery, LayerDTO>
    {
        public Task<LayerDTO> Handle(FindLayerByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
