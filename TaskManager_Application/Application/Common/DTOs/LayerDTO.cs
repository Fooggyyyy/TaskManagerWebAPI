using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Common.DTOs
{
    public class LayerDTO 
    {
        public int LayerID { get; set; }
        public string? LayerName { get; set; }

        public LayerDTO()
        {

        }
        public LayerDTO(int layerID, string? layerName)
        {
            LayerID = layerID;
            LayerName = layerName;
        }
    }
}
