using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys
{
    public class GetAllCommentsQuery : IRequest<ICollection<CommentDTO>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetAllCommentsQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public GetAllCommentsQuery() { }
    }
}
