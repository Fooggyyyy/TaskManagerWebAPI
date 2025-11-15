using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;

namespace TaskManager_Application.Application.Events.Querys.Handlers.CommentHandlers
{
    public class GetAllCommentsQueryHandler(ICommentRepository CommentRepository, IMapper Mapper)
       : IRequestHandler<GetAllCommentsQuery, ICollection<CommentDTO>>
    {
        public async Task<ICollection<CommentDTO>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var AllComments = await CommentRepository.GetAll(cancellationToken);

            var PagedComments = AllComments.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<CommentDTO>>(PagedComments);
        }
    }
}
