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
    public class ExitUserCommandHandler(IRefreshTokenRepository RefreshTokenRepository)
        : IRequestHandler<ExitUserCommand, Unit>
    {
        public async Task<Unit> Handle(ExitUserCommand request, CancellationToken cancellationToken)
        {
            var AllTokens = await RefreshTokenRepository.GetAll(cancellationToken);

            var TokensToDelete = AllTokens.Where(x => x.Token == request.RefreshToken).ToList();

            foreach(var token in TokensToDelete)
                await RefreshTokenRepository.DeleteById(token.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
