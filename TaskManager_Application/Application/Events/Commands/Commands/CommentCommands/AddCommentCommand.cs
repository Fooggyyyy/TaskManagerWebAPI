using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.CommentCommands
{
    public class AddCommentCommand : IRequest<Unit>
    {
        public string? CommentBody { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public int TaskID { get; set; }
        public int UserID { get; set; }

        public AddCommentCommand()
        {
            
        }
        public AddCommentCommand(string? commentBody, DateOnly releaseDate, int taskID, int userID)
        {
            CommentBody = commentBody;
            ReleaseDate = releaseDate;
            TaskID = taskID;
            UserID = userID;
        }
    }
}
