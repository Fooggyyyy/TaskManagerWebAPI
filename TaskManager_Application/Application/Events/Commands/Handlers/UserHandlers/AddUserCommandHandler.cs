using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Common.HashHelper;
using TaskManager_Application.Application.Common.JWT.JWTService;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.UserHandlers
{
    public class AddUserCommandHandler(IUserRepository UserRepository, IMapper Mapper, IValidator<UserDTO> Validator, IHashPassword HashPassword)
        : IRequestHandler<AddUserCommand, Unit>
    {
        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var dto = Mapper.Map<UserDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<User>(dto);
            Result.Password = HashPassword.HashPassword(Result.Password);

            await UserRepository.Add(Result, cancellationToken);

            return Unit.Value;
        }
    }
}
