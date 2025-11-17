using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Common.DTOs
{
    public class CommentDTO
    {
        public int CommentID { get; set; }

        public int UserID { get; set; }
        public int TaskID { get; set; }

        public string? CommentBody { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public CommentDTO()
        {

        }
        public CommentDTO(int commentID, string? commentBody, DateOnly releaseDate, int userID, int taskID)
        {
            CommentID = commentID;
            CommentBody = commentBody;
            ReleaseDate = releaseDate;
            UserID = userID;
            TaskID = taskID;
        }
    }
}
