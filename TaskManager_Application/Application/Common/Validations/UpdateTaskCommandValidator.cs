using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.TaskCommands;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Common.Validations
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator() 
        {
            RuleFor(x => x.TaskID)
                .GreaterThan(0).WithMessage("ID задачи должен быть больше 0");
            RuleFor(x => x.TaskName)
                .MinimumLength(3).WithMessage("Имя задачи не может быть короче 3 символов")
                .MaximumLength(20).WithMessage("Имя задачи не может быть длинее 20 символов")
                .When(x => !string.IsNullOrWhiteSpace(x.TaskName));
            RuleFor(x => x.Description)
                .MinimumLength(10).WithMessage("Описание задачи не может быть короче 10 символов")
                .MaximumLength(2000).WithMessage("Описание задачи не может быть длинее 2000 символов")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));
            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("Приоритет задачи должен быть перечислением")
                .When(x => x.Priority != default(Priority));
        }
    }
}

