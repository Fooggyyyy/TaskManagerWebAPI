using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.TaskQuerys
{
    public class FindTaskByIdQuery : IRequest<TaskDTO>
    {
        public int Id { get; set; }

        public FindTaskByIdQuery(int id)
        {
            Id = id;
        }

        public FindTaskByIdQuery() { }
    }
}
