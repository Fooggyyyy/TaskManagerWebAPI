using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Enums;

namespace TaskManager_Application.Application.Common.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public int ProjectID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }
        public UserDTO()
        {

        }
        public UserDTO(int userID, string? fullName, string? email, string? password, Role role, int projectId)
        {
            UserID = userID;
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
            ProjectID = projectId;
        }
    }
}
