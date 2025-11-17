using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Commands.Handlers.UserHandlers
{
    public class DeleteAllUsersCommandHandler(IUserRepository UserRepository)
        : IRequestHandler<DeleteAllUsersCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
        {
            await UserRepository.DeleteAll(cancellationToken);
            return Unit.Value;
        }
    }
}
