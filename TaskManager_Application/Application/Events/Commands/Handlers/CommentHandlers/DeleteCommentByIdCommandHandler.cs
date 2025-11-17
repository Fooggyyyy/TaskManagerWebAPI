using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.CommentCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.CommentHandlers
{
    public class DeleteCommentByIdCommandHandler(ICommentRepository CommentRepository)
        : IRequestHandler<DeleteCommentByIdCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
        {
            await CommentRepository.DeleteById(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
