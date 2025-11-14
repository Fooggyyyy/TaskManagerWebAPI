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
#pragma warning disable CS9113
    public class DeleteCommentByIdCommandHandler(ICommentRepository CommentRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<DeleteCommentByIdCommand, Unit>
    {
        public Task<Unit> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
