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
    public class DeleteUserByIdCommandHandler(IUserRepository UserRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<DeleteUserByIdCommand, Unit>
    {
        public Task<Unit> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
