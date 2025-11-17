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
    public class TaskValidator : AbstractValidator<TaskDTO>
    {
        public TaskValidator() 
        {
            RuleFor(x => x.TaskName)
                .NotNull().WithMessage("Имя задачи не может быть пустым")
                .MinimumLength(3).WithMessage("Имя задачи не может быть короче 3 символов")
                .MaximumLength(20).WithMessage("Имя задачи не может быть длинее 20 символов");
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Описание задачи не может быть пустым")
                .MinimumLength(10).WithMessage("Описание задачи не может быть короче 10 символов")
                .MaximumLength(2000).WithMessage("Описание задачи не может быть длинее 2000 символов");
            RuleFor(x => x.Priority)
                .NotNull().WithMessage("Приоритет задачи не может быть пустым")
                .IsInEnum().WithMessage("Приоритет задачи быть перечеслением");
            RuleFor(x => x.DateStart)
                .NotNull().WithMessage("Дата старта задачи не может быть пустым")
                .Equal(DateOnly.FromDateTime(DateTime.Today));
            RuleFor(x => x.DateEnd)
                .NotNull().WithMessage("Дата старта задачи не может быть пустым")
                .GreaterThanOrEqualTo(y => y.DateStart).WithMessage("Задача должна быть завершена позже или в день ее начала");
            RuleFor(x => x.IsCompleted)
                .NotNull().WithMessage("Статус выполнения задачи не может быть пустым");
        }
    }
}
