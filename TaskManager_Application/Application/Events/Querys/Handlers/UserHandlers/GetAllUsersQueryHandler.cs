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
#pragma warning disable CS9113
    public class GetAllUsersQueryHandler(IUserRepository UserRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<GetAllUsersQuery, ICollection<UserDTO>>
    {
        public Task<ICollection<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
