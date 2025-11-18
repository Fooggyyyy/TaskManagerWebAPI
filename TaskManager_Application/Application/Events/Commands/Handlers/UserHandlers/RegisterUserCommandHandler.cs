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
using TaskManager_Domain.Domain.Enums;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.UserHandlers
{
    public class RegisterUserCommandHandler(IUserRepository UserRepository, IRefreshTokenRepository RefreshTokenRepository,  IMapper Mapper, IValidator<UserDTO> Validator, IJwtService JwtService, IHashPassword HashPassword)
        : IRequestHandler<RegisterUserCommand, object>
    {
        public async Task<object> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var AllUsers = await UserRepository.GetAll(cancellationToken);
            var HasMail = AllUsers.Where(x => x.Email == request.Email).Any();
            if (HasMail)
                throw new ValidationException("Пользователь с такой почтой уже существует");

            var dto = Mapper.Map<UserDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<User>(dto);
            Result.Password = HashPassword.HashPassword(Result.Password);

            await UserRepository.Add(Result, cancellationToken);
            var AllUser = await UserRepository.GetAll(cancellationToken);

            int UserID = AllUser.Where(x => x.Email == request.Email).Select(y => y.UserID).FirstOrDefault();

            var AccesToken = await JwtService.GenerateToken(UserID, request.Email, Role.Client);
            var RefreshToken = await JwtService.GenerateRefreshToken();

            var DbRefreshToken = new RefreshToken(RefreshToken, UserID, DateTime.Now.AddDays(7), Result);
            await RefreshTokenRepository.Add(DbRefreshToken, cancellationToken);

            return new { AccesToken, RefreshToken };
        }
    }
}
