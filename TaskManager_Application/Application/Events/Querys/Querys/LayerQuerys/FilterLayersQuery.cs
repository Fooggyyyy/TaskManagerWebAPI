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
        public int Page { get; set; }
        public int PageSize { get; set; }

        public FilterLayersQuery(string? layerName, int page, int pageSize)
        {
            LayerName = layerName;
            Page = page;
            PageSize = pageSize;
        }

        public FilterLayersQuery() { }
    }
}
