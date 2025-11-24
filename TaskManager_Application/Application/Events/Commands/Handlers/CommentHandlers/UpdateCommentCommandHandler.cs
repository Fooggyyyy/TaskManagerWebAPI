using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.CommentCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

namespace TaskManager_Application.Application.Events.Commands.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler(ICommentRepository CommentRepository, IValidator<UpdateCommentCommand> Validator)
        : IRequestHandler<UpdateCommentCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            await Validator.ValidateAndThrowAsync(request, cancellationToken);
            await CommentRepository.Update(request.CommentID, request.CommentBody ?? string.Empty, cancellationToken);

            return Unit.Value;
        }
    }
}
