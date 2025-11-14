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
    public class DeleteAllLayersCommandHandler(ILayerRepository LayerRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<DeleteAllLayersCommand, Unit>
    {
        public Task<Unit> Handle(DeleteAllLayersCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
