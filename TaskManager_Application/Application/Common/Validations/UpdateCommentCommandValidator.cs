using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.CommentCommands;

namespace TaskManager_Application.Application.Common.Validations
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator() 
        {
            RuleFor(x => x.CommentID)
                .GreaterThan(0).WithMessage("ID комментария должен быть больше 0");
            RuleFor(x => x.CommentBody)
                .MaximumLength(500).WithMessage("Комментарий не может быть длинее 500 символов")
                .When(x => !string.IsNullOrWhiteSpace(x.CommentBody));
        }
    }
}

