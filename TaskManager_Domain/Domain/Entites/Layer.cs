using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Domain.Domain.Entites
{
    public class Layer
    {
        public int LayerID { get; set; }

        public int ProjectID {  get; set; }
        public Project? Project { get; set; }

        public string? LayerName { get; set; }

        public Layer(int layerID, int projectID, Project? project, string? layerName)
        {
            LayerID = layerID;
            ProjectID = projectID;
            Project = project;
            LayerName = layerName;
        }

        public Layer(int layerID, int projectID, string? layerName)
        {
            LayerID = layerID;
            ProjectID = projectID;
            LayerName = layerName;
        }

        public Layer()
        {
        }
    }
}
