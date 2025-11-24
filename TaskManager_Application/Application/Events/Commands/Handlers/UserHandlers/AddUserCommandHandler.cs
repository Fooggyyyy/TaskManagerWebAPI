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
    public class AddUserCommandHandler(IUserRepository UserRepository, IProjectRepository ProjectRepository, IRefreshTokenRepository RefreshTokenRepository, IMapper Mapper, IValidator<UserDTO> Validator, IHashPassword HashPassword, IJwtService JwtService)
        : IRequestHandler<AddUserCommand, object>
    {
        public async Task<object> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var AllUsers = await UserRepository.GetAll(cancellationToken);
            var HasMail =  AllUsers.Where(x => x.Email == request.Email).Any();
            if (HasMail)
                throw new ValidationException("Пользователь с такой почтой уже существует");

            // Verify project exists
            var project = await ProjectRepository.FindById(request.ProjectId, cancellationToken);
            if (project == null)
                throw new ValidationException($"Проект с ID {request.ProjectId} не найден");

            var dto = Mapper.Map<UserDTO>(request);
            await Validator.ValidateAndThrowAsync(dto, cancellationToken);

            var Result = Mapper.Map<User>(dto);
            Result.Password = HashPassword.HashPassword(Result.Password);

            await UserRepository.Add(Result, cancellationToken);
            var AllUser = await UserRepository.GetAll(cancellationToken);

            int UserID = AllUser.Where(x => x.Email == request.Email).Select(y => y.UserID).FirstOrDefault();

            var AccesToken = await JwtService.GenerateToken(UserID, request.Email, request.Role);
            var RefreshToken = await JwtService.GenerateRefreshToken();

            var DbRefreshToken = new RefreshToken(RefreshToken, UserID, DateTime.Now.AddDays(7));
            await RefreshTokenRepository.Add(DbRefreshToken, cancellationToken);

            return new { AccesToken, RefreshToken };
        }
    }
}
