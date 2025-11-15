using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Events.Querys.Querys.ProjectQuerys
{
    public class FilterProjectsQuery : IRequest<ICollection<ProjectDTO>>
    {
        public string? ProjectName { get; set; }
        public Status? Status { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }

        public FilterProjectsQuery(string? projectName, Status? Status, int page, int pageSize)
        {
            ProjectName = projectName;
            this.Status = Status;
            Page = page;
            PageSize = pageSize;
        }

        public FilterProjectsQuery() { }
    }
}
