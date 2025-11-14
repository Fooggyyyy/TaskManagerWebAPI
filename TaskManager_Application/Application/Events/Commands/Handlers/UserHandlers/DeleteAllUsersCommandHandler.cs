using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.UserHandlers
{
#pragma warning disable CS9113
    public class DeleteAllUsersCommandHandler(IUserRepository UserRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<DeleteAllUsersCommand, Unit>
    {
        public Task<Unit> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
