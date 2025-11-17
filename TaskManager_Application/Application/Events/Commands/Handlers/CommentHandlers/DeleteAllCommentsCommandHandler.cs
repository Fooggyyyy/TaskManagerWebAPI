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
    public class DeleteAllCommentsCommandHandler(ICommentRepository CommentRepository)
        : IRequestHandler<DeleteAllCommentsCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAllCommentsCommand request, CancellationToken cancellationToken)
        {
            await CommentRepository.DeleteAll(cancellationToken);
            return Unit.Value;
        }
    }
}
