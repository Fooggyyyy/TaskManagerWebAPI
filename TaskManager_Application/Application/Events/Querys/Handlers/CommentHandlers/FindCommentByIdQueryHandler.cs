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
    public class FindCommentByIdQueryHandler(ICommentRepository CommentRepository, IMapper Mapper)
        : IRequestHandler<FindCommentByIdQuery, CommentDTO>
    {
        public async Task<CommentDTO> Handle(FindCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var Comment = await CommentRepository.FindById(request.Id, cancellationToken);

            return Mapper.Map<CommentDTO>(Comment);
        }
    }
}
