using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.JWT.JWTService;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler(IUserRepository UserRepository, IRefreshTokenRepository RefreshTokenRepository,IJwtService JwtService, IValidator<UpdateUserCommand> Validator)
        : IRequestHandler<UpdateUserCommand, object>
    {
        public async Task<object> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await UserRepository.FindById(request.ID, cancellationToken) ?? throw new ValidationException("Пользователь не найден");

            await Validator.ValidateAndThrowAsync(request, cancellationToken);

            var AccesToken = await JwtService.GenerateToken(request.ID, user.Password, request.Role);
            var RefreshToken = await JwtService.GenerateRefreshToken();

            var DbRefreshToken = new RefreshToken(RefreshToken, user.UserID, DateTime.Now.AddDays(7), user);
            await RefreshTokenRepository.Add(DbRefreshToken, cancellationToken);
            await UserRepository.Update(request.ID, request.FullName, request.Email, request.Role, cancellationToken);

            return new {AccesToken,  RefreshToken};
        }
    }
}
