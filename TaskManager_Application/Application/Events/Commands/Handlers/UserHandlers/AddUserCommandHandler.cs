using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.HashHelper;
using TaskManager_Application.Application.Common.JWT.JWTService;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.UserHandlers
{
#pragma warning disable CS9113
    public class AddUserCommandHandler(IUserRepository UserRepository, IMapper Mapper, IValidator Validator, IJwtService JwtService, IHashPassword hashPassword)
        : IRequestHandler<AddUserCommand, Unit>
    {
        public Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
