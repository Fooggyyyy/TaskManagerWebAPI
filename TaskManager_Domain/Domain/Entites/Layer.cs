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
        public virtual Project? Project { get; set; }

        public string? LayerName { get; set; }

        public virtual List<TaskManager_Domain.Domain.Entites.Task> Tasks { get; set; } = null!;
        public Layer(int layerID, int projectID, Project? project, string? layerName, List<Task> tasks)
        {
            LayerID = layerID;
            ProjectID = projectID;
            Project = project;
            LayerName = layerName;
            Tasks = tasks;
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
