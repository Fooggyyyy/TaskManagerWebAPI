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
    public class FilterCommentsQueryHandler(ICommentRepository CommentRepository, IMapper Mapper)
        : IRequestHandler<FilterCommentsQuery, ICollection<CommentDTO>>
    {
        public async Task<ICollection<CommentDTO>> Handle(FilterCommentsQuery request, CancellationToken cancellationToken)
        {
            var FilterComments = await CommentRepository.Filter(request.CommentReleaseDateStart, cancellationToken);

            var PagedComments = FilterComments.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize).ToList();

            return Mapper.Map<ICollection<CommentDTO>>(PagedComments);
        }
    }
}
