using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Common.Validations
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator() 
        {
            RuleFor(x => x.NotificationName)
                .NotNull().WithMessage("Имя уведомления не может быть пустым")
                .MinimumLength(3).WithMessage("Имя уведомления не может быть короче 3 символов")
                .MaximumLength(20).WithMessage("Имя уведомления не может быть длинее 20 символов");
            RuleFor(x => x.NotificationDescription)
                .NotNull().WithMessage("Описание уведомления не может быть пустым");
        }
    }
}
