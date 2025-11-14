using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Application.Application.Events.Commands.Commands.CommentCommands
{
    public class DeleteCommentByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteCommentByIdCommand(int Id)
        {
            this.Id = Id;
        }

        public DeleteCommentByIdCommand()
        {

        }
    }
}
