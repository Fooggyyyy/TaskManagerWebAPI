using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Common.Validations
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            RuleFor(x => x.ID)
                .GreaterThan(0).WithMessage("ID пользователя должен быть больше 0");
            RuleFor(x => x.FullName)
                .MinimumLength(10).WithMessage("Имя пользователя не может быть короче 10 символов")
                .MaximumLength(50).WithMessage("Имя пользователя не может быть длинее 50 символов")
                .When(x => !string.IsNullOrWhiteSpace(x.FullName));
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Не корректный Email пользователя")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));
            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Роль пользователя должна быть перечислением")
                .When(x => x.Role != default(Role));
        }
    }
}

