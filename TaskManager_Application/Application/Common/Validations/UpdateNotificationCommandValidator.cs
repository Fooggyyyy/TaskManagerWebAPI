using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands;

namespace TaskManager_Application.Application.Common.Validations
{
    public class UpdateNotificationCommandValidator : AbstractValidator<UpdateNotificationCommand>
    {
        public UpdateNotificationCommandValidator() 
        {
            RuleFor(x => x.NotificationID)
                .GreaterThan(0).WithMessage("ID уведомления должен быть больше 0");
            RuleFor(x => x.NotificationName)
                .MinimumLength(3).WithMessage("Имя уведомления не может быть короче 3 символов")
                .MaximumLength(20).WithMessage("Имя уведомления не может быть длинее 20 символов")
                .When(x => !string.IsNullOrWhiteSpace(x.NotificationName));
            RuleFor(x => x.NotificationDescription)
                .NotEmpty().WithMessage("Описание уведомления не может быть пустым")
                .When(x => !string.IsNullOrWhiteSpace(x.NotificationDescription));
        }
    }
}

