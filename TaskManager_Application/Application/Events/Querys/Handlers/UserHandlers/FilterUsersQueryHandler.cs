using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.TaskQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.UserQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.UserHandlers
{
#pragma warning disable CS9113
    public class FilterUsersQueryHandler(IUserRepository UserRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<FilterUsersQuery, ICollection<UserDTO>>
    {
        public Task<ICollection<UserDTO>> Handle(FilterUsersQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
