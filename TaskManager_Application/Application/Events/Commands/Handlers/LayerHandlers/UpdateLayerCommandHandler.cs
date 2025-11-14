using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.LayerCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.LayerHandlers
{
    #pragma warning disable CS9113
    public class UpdateLayerCommandHandler(ILayerRepository LayerRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<UpdateLayerCommand, Unit>
    {
        public Task<Unit> Handle(UpdateLayerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
