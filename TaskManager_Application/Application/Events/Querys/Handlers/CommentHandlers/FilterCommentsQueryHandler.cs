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
#pragma warning disable CS9113
    public class FilterCommentsQueryHandler(ICommentRepository CommentRepository, IMapper Mapper, IValidator Validator)
        : IRequestHandler<FilterCommentsQuery, ICollection<CommentDTO>>
    {
        public Task<ICollection<CommentDTO>> Handle(FilterCommentsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
