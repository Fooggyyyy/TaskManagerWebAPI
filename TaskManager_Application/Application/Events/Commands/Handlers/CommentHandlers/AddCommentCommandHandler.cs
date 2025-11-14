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
    public class AddCommentCommandHandler(ICommentRepository CommentRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<AddCommentCommand, Unit>
    {
        public Task<Unit> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
