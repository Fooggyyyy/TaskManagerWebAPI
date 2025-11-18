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

            var CurrentUserIDList = AllTokens.Where(x => x.Token == request.RefreshToken).Select(y => y.UserId).ToList();

            foreach(var id in CurrentUserIDList)
                await RefreshTokenRepository.DeleteById(id, cancellationToken);
            return Unit.Value;
        }
    }
}
