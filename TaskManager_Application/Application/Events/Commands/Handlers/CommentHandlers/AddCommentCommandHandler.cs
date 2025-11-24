using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.CommentCommands;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.CommentHandlers
{
    public class AddCommentCommandHandler(ICommentRepository CommentRepository, ITaskRepository TaskRepository, IUserRepository UserRepository, IMapper Mapper, IValidator<CommentDTO> Validator)
        : IRequestHandler<AddCommentCommand, Unit>
    {
        public async Task<Unit> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            // Verify foreign keys exist
            var task = await TaskRepository.FindById(request.TaskID, cancellationToken);
            if (task == null)
                throw new ValidationException($"Задача с ID {request.TaskID} не найдена");

            var user = await UserRepository.FindById(request.UserID, cancellationToken);
            if (user == null)
                throw new ValidationException($"Пользователь с ID {request.UserID} не найден");

            var dto = Mapper.Map<CommentDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<Comment>(dto);

            await CommentRepository.Add(Result, cancellationToken);

            return Unit.Value;
        }
    }
}
