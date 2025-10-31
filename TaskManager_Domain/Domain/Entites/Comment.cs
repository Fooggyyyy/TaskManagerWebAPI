using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Domain.Domain.Entites
{
    public class Comment
    {
        public int CommentID { get; set; }
        
        public int TaskID { get; set; }
        public Task? Task { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        public string? CommentBody {  get; set; }
        public DateOnly ReleaseDate { get; set; }

        public Comment(int commentID, int taskID, Task? task,
            int userID, User? user, string? commentBody, DateOnly releaseDate)
        {
            CommentID = commentID;
            TaskID = taskID;
            Task = task;
            UserID = userID;
            User = user;
            CommentBody = commentBody;
            ReleaseDate = releaseDate;
        }

        public Comment(int commentID, int taskID, 
            int userID, string? commentBody, DateOnly releaseDate)
        {
            CommentID = commentID;
            TaskID = taskID;
            UserID = userID;
            CommentBody = commentBody;
            ReleaseDate = releaseDate;
        }

        public Comment()
        {
        }
    }
}
