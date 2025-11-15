using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.UserQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.UserHandlers
{
    public class FindUserByIdQueryHandler(IUserRepository UserRepository, IMapper Mapper)
        : IRequestHandler<FindUserByIdQuery, UserDTO>
    {
        public async Task<UserDTO> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
        {
            var User = await UserRepository.FindById(request.Id, cancellationToken);

            return Mapper.Map<UserDTO>(User);
        }
    }
}
