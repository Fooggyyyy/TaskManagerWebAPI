using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? CommentBody { get; set; }

        public UpdateCommentCommand(int id, string? commentBody) 
        {
            Id = id;
            CommentBody = commentBody;
        }

        public UpdateCommentCommand()
        {

        }
    }
}
