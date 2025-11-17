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
        public int ProjectID { get; set; }
        public string? LayerName { get; set; }

        public LayerDTO()
        {

        }
        public LayerDTO(int layerID, string? layerName, int projectID)
        {
            LayerID = layerID;
            LayerName = layerName;
            ProjectID = projectID;
        }
    }
}
