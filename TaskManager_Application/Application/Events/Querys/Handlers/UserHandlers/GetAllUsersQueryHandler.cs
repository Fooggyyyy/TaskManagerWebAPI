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
    public class GetAllUsersQueryHandler(IUserRepository UserRepository, IMapper Mapper)
        : IRequestHandler<GetAllUsersQuery, ICollection<UserDTO>>
    {
        public async Task<ICollection<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var AllUsers = await UserRepository.GetAll(cancellationToken);

            var PagedUsers = AllUsers.Take((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<UserDTO>>(PagedUsers);
        }
    }
}
