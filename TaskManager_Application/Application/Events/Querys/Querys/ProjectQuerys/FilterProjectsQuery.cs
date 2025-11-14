using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.ProjectQuerys
{
    public class FilterProjectsQuery : IRequest<ICollection<ProjectDTO>>
    {
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }

        public FilterProjectsQuery(string? projectName, string? projectDescription)
        {
            ProjectName = projectName;
            ProjectDescription = projectDescription;
        }

        public FilterProjectsQuery() { }
    }
}
