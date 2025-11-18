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
    public class ResetPasswordUserCommandHandler(IUserRepository UserRepository, IRefreshTokenRepository RefreshTokenRepository, IValidator<ResetPasswordUserCommand> Validator, IHashPassword HashPassword, IJwtService JwtService)
        : IRequestHandler<ResetPasswordUserCommand, object>
    {
        public async Task<object> Handle(ResetPasswordUserCommand request, CancellationToken cancellationToken)
        {
            await Validator.ValidateAndThrowAsync(request, cancellationToken);

            request.OldPassword = HashPassword.HashPassword(request.OldPassword);
            request.NewPassword = HashPassword.HashPassword(request.NewPassword);

            var UserInDB = await UserRepository.FindById(request.Id, cancellationToken) ?? new User();
            if (UserInDB.Email == null)
                throw new ValidationException("Такой User не найден");

            var NewAccesToken = JwtService.GenerateToken(request.Id, UserInDB.Email, UserInDB.Role);
            var RefreshToken = JwtService.GenerateRefreshToken();

            var DbRefreshToken = new RefreshToken(RefreshToken.Result, request.Id, DateTime.Now.AddDays(7), UserInDB);
            await RefreshTokenRepository.Add(DbRefreshToken, cancellationToken);

            await UserRepository.ResetPassword(request.Id, request.OldPassword, request.NewPassword, cancellationToken);
            return new { NewAccesToken, RefreshToken };
        }
    }
}
