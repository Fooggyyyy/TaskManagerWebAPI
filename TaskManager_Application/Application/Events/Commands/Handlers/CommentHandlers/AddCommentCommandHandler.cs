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
    public class AddCommentCommandHandler(ICommentRepository CommentRepository, IMapper Mapper, IValidator<CommentDTO> Validator)
        : IRequestHandler<AddCommentCommand, Unit>
    {
        public async Task<Unit> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var dto = Mapper.Map<CommentDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<Comment>(dto);

            await CommentRepository.Add(Result, cancellationToken);

            return Unit.Value;
        }
    }
}
