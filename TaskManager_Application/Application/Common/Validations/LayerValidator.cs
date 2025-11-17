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
    public class LayerValidator : AbstractValidator<LayerDTO>
    {
        public LayerValidator() 
        {
            RuleFor(x => x.LayerName)
                .NotNull().WithMessage("Имя слоя не может быть пустым")
                .MinimumLength(3).WithMessage("Имя слоя не может быть короче 3 символов")
                .MaximumLength(20).WithMessage("Имя слоя не может быть длинее 20 символов");
        } 
    }
}
