using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Common.Validations
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator() 
        {
            RuleFor(x => x.ProjectName)
                .NotNull().WithMessage("Имя проекта не может быть пустым")
                .MinimumLength(3).WithMessage("Имя проекта не может быть короче 3 символов")
                .MaximumLength(20).WithMessage("Имя проекта не может быть длинее 20 символов");
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Описание проекта не может быть пустым")
                .MinimumLength(10).WithMessage("Описание проекта не может быть короче 10 символов")
                .MaximumLength(2000).WithMessage("Описание проекта не может быть длинее 2000 символов");
            RuleFor(x => x.Status)
                .NotNull().WithMessage("Статус проекта не может быть пустым")
                .IsInEnum().WithMessage("Статус должен быть перечеслением");
        }
    }
}
