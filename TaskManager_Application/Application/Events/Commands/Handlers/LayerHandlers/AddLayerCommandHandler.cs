using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.LayerCommands;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.LayerHandlers
{
    public class AddLayerCommandHandler(ILayerRepository LayerRepository, IProjectRepository ProjectRepository, IMapper Mapper, IValidator<LayerDTO> Validator)
        : IRequestHandler<AddLayerCommand, Unit>
    {
        public async Task<Unit> Handle(AddLayerCommand request, CancellationToken cancellationToken)
        {
            // Verify foreign key exists
            var project = await ProjectRepository.FindById(request.ProjectID, cancellationToken);
            if (project == null)
                throw new ValidationException($"Проект с ID {request.ProjectID} не найден");

            var dto = Mapper.Map<LayerDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var AllLayers = await LayerRepository.GetAll(cancellationToken);

            var LayerName = AllLayers.Where(x => x.LayerName == request.LayerName && x.ProjectID == request.ProjectID).Select(y => y.LayerName).FirstOrDefault();
            if (LayerName != null)
                throw new ArgumentException("Не может быть два одинаковых слоя в одном проекте");

            var Result = Mapper.Map<Layer>(dto);

            await LayerRepository.Add(Result, cancellationToken);

            return Unit.Value;
        }
    }
}
