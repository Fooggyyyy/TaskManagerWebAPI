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
        public string? CommentReleaseDateStart { get; set; }

        public FilterCommentsQuery(string? commentReleaseDateStart)
        {
            CommentReleaseDateStart = commentReleaseDateStart;
        }

        public FilterCommentsQuery()
        {
        }
    }
}
