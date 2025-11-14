using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;

namespace TaskManager_Application.Application.Events.Querys.Querys.LayerQuerys
{
    public class FilterLayersQuery : IRequest<ICollection<LayerDTO>>
    {
        public string? LayerName { get; set; }

        public FilterLayersQuery(string? LayerName)
        {
            this.LayerName = LayerName;
        }

        public FilterLayersQuery() { }
    }
}
