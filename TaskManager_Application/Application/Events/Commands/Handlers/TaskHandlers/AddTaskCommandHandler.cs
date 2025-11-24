using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.TaskCommands;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.TaskHandlers
{
    public class AddTaskCommandHandler(ITaskRepository TaskRepository, ILayerRepository LayerRepository, IProjectRepository ProjectRepository, IUserRepository UserRepository, IMapper Mapper, IValidator<TaskDTO> Validator)
        : IRequestHandler<AddTaskCommand, Unit>
    {
        public async Task<Unit> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            // Verify foreign keys exist
            var layer = await LayerRepository.FindById(request.LayerId, cancellationToken);
            if (layer == null)
                throw new ValidationException($"Слой с ID {request.LayerId} не найден");

            var project = await ProjectRepository.FindById(request.ProjectId, cancellationToken);
            if (project == null)
                throw new ValidationException($"Проект с ID {request.ProjectId} не найден");

            var user = await UserRepository.FindById(request.UserId, cancellationToken);
            if (user == null)
                throw new ValidationException($"Пользователь с ID {request.UserId} не найден");

            var dto = Mapper.Map<TaskDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<TaskManager_Domain.Domain.Entites.Task>(dto);

            await TaskRepository.Add(Result, cancellationToken);

            return Unit.Value;
        }
    }
}
