using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.ProjectQuerys
{
    public class FindProjectByIdQuery : IRequest<ProjectDTO>
    {
        public int Id { get; set; }

        public FindProjectByIdQuery(int id)
        {
            Id = id;
        }

        public FindProjectByIdQuery() { }
    }
}
