using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys
{
    public class FindCommentByIdQuery : IRequest<CommentDTO>
    {
        public int Id { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }

        public FindCommentByIdQuery(int id, int page, int pageSize)
        {
            Id = id;
            Page = page;
            PageSize = pageSize;
        }

        public FindCommentByIdQuery() { }
    }
}
