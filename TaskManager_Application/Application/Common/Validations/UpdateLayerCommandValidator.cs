using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.LayerCommands;

namespace TaskManager_Application.Application.Common.Validations
{
    public class UpdateLayerCommandValidator : AbstractValidator<UpdateLayerCommand>
    {
        public UpdateLayerCommandValidator() 
        {
            RuleFor(x => x.LayerID)
                .GreaterThan(0).WithMessage("ID слоя должен быть больше 0");
            RuleFor(x => x.LayerName)
                .MinimumLength(3).WithMessage("Имя слоя не может быть короче 3 символов")
                .MaximumLength(20).WithMessage("Имя слоя не может быть длинее 20 символов")
                .When(x => !string.IsNullOrWhiteSpace(x.LayerName));
        } 
    }
}

