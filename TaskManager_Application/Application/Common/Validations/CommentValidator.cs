using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Common.Validations
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator() 
        {
            RuleFor(x => x.CommentBody)
                .NotNull().WithMessage("Комментарий не может быть пустым")
                .MaximumLength(500).WithMessage("Комментарий не может быть длинее 500 символов");
            RuleFor(x => x.ReleaseDate)
                .NotNull().WithMessage("Дата не может быть пустой")
                .Equal(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Комменатрий не может быть оставлен не в актуальную дату");
        }
    }
}
