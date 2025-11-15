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
    public class FilterUsersQueryHandler(IUserRepository UserRepository, IMapper Mapper)
        : IRequestHandler<FilterUsersQuery, ICollection<UserDTO>>
    {
        public async Task<ICollection<UserDTO>> Handle(FilterUsersQuery request, CancellationToken cancellationToken)
        {
            var FilterUsers = await UserRepository.Filter(request.FullName, request.Email, request.Role, cancellationToken);

            var PagedUsers = FilterUsers.Take((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<UserDTO>>(PagedUsers);
        }
    }
}
