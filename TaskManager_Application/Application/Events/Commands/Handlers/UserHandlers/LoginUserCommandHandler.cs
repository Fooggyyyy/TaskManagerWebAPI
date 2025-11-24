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
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.UserHandlers
{
    public class LoginUserCommandHandler(IUserRepository UserRepository, IRefreshTokenRepository RefreshTokenRepository, IJwtService JwtService, IHashPassword HashPassword)
        : IRequestHandler<LoginUserCommand, object>
    {
        public async Task<object> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var AllUsers = await UserRepository.GetAll(cancellationToken);

            var user = AllUsers.FirstOrDefault(x => x.Email == request.Email) ?? throw new ValidationException("Пользователь не найден");

            if (!HashPassword.Verify(request.Password, user.Password))
                throw new ValidationException("Неверный пароль");

            var accessToken = await JwtService.GenerateToken(user.UserID, user.Email, user.Role);
            var refreshToken = await JwtService.GenerateRefreshToken();

            var dbRefreshToken = new RefreshToken(refreshToken, user.UserID, DateTime.Now.AddDays(7));
            await RefreshTokenRepository.Add(dbRefreshToken, cancellationToken);

            return new { accessToken, refreshToken };
        }
    }
}
