using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys
{
    public class FilterCommentsQuery : IRequest<ICollection<CommentDTO>>
    {
        public DateOnly? CommentReleaseDateStart { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public FilterCommentsQuery(DateOnly? commentReleaseDateStart, int Page, int PageSize)
        {
            CommentReleaseDateStart = commentReleaseDateStart;
            this.Page = Page;
            this.PageSize = PageSize;
        }

        public FilterCommentsQuery()
        {
        }
    }
}
