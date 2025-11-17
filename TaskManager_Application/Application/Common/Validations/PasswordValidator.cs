using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;

namespace TaskManager_Application.Application.Common.Validations
{
    public class PasswordValidator : AbstractValidator<ResetPasswordUserCommand>
    {
        public PasswordValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Старый пароль обязателен");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Новый пароль обязателен")
                .MinimumLength(8).WithMessage("Пароль должен быть минимум 8 символов")
                .Matches("[A-Z]").WithMessage("Пароль должен содержать хотя бы одну заглавную букву")
                .Matches("[a-z]").WithMessage("Пароль должен содержать хотя бы одну строчную букву")
                .Matches("[0-9]").WithMessage("Пароль должен содержать хотя бы одну цифру")
                .Matches("[^a-zA-Z0-9]").WithMessage("Пароль должен содержать спецсимвол");
        }
    }
}
