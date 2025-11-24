using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Common.Validations
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator() 
        {
            RuleFor(x => x.ProjectID)
                .GreaterThan(0).WithMessage("ID проекта должен быть больше 0");
            RuleFor(x => x.ProjectName)
                .MinimumLength(3).WithMessage("Имя проекта не может быть короче 3 символов")
                .MaximumLength(20).WithMessage("Имя проекта не может быть длинее 20 символов")
                .When(x => !string.IsNullOrWhiteSpace(x.ProjectName));
            RuleFor(x => x.Description)
                .MinimumLength(10).WithMessage("Описание проекта не может быть короче 10 символов")
                .MaximumLength(2000).WithMessage("Описание проекта не может быть длинее 2000 символов")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Статус должен быть перечислением")
                .When(x => x.Status != default(Status));
        }
    }
}

