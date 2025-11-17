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
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.UserHandlers
{
    public class ResetPasswordUserCommandHandler(IUserRepository UserRepository, IValidator<ResetPasswordUserCommand> Validator, IHashPassword HashPassword)
        : IRequestHandler<ResetPasswordUserCommand, Unit>
    {
        public async Task<Unit> Handle(ResetPasswordUserCommand request, CancellationToken cancellationToken)
        {
            await Validator.ValidateAndThrowAsync(request, cancellationToken);

            request.OldPassword = HashPassword.HashPassword(request.OldPassword);
            request.NewPassword = HashPassword.HashPassword(request.NewPassword);

            await UserRepository.ResetPassword(request.Id, request.OldPassword, request.NewPassword, cancellationToken);
            return Unit.Value;
        }
    }
}
