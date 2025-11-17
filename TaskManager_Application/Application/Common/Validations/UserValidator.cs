using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Domain.Domain.Entites;

namespace TaskManager_Application.Application.Common.Validations
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator() 
        {
            RuleFor(x => x.FullName)
                .NotNull().WithMessage("Имя пользователя не может быть пустым")
                .MinimumLength(10).WithMessage("Имя пользователя не может быть короче 10 символов")
                .MaximumLength(50).WithMessage("Имя пользователя не может быть длинее 50 символов");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Не корректный Email пользователя");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("Пароль пользователя не должен быть пустым")
                .MinimumLength(8).WithMessage("Пароль пользователя не может быть короче 8 символов")
                .Matches("[A-Z]").WithMessage("Пароль пользователя должен иметь заглавную букву")
                .Matches("[a-z]").WithMessage("Пароль пользователя должен иметь строчную букву")
                .Matches("[0-9]").WithMessage("Пароль пользователя должен иметь цифру")
                .Matches("[^a-zA-Z0-9]").WithMessage("Пароль пользователя должен иметь спецсимвол");
            RuleFor(x => x.Role)
                .NotNull().WithMessage("Роль пользователя не может быть пустой")
                .IsInEnum().WithMessage("Роль пользователя должна быть перечислением");
        }
    }
}
