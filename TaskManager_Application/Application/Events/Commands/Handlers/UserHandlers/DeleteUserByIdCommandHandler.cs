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
    public class DeleteUserByIdCommandHandler(IUserRepository UserRepository)
        : IRequestHandler<DeleteUserByIdCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            await UserRepository.DeleteById(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
