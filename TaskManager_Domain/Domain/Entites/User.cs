using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Domain.Domain.Entites
{
    public class User
    {
        public int UserID { get; set; }

        public int ProjectID { get; set; }
        public Project? Project { get; set; }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }

        public User(int userID, int projectID, Project? project, string? fullName, string? email, string? password, Role role)
        {
            UserID = userID;
            ProjectID = projectID;
            Project = project;
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        }

        public User(int userID, int projectID, string? fullName, string? email, string? password, Role role)
        {
            UserID = userID;
            ProjectID = projectID;
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        }

        public User(int userID, int projectID, string? fullName, string? email, string? password)
        {
            UserID = userID;
            ProjectID = projectID;
            FullName = fullName;
            Email = email;
            Password = password;
            Role = 0;
        }

        public User()
        {
        }
    }
}
