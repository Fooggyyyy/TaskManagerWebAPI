using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.CommentCommands;
using TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands;
using TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.LayerQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.NotificationQuerys;

namespace TaskManager_WebAPI.WebAPI.Controller
{
    [ApiController]
    [Route("API/Notification/")]
    public class NotificationController(IMediator Mediator) : ControllerBase
    {
        [HttpGet("All")]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<NotificationDTO>>> GetAll(CancellationToken cancellationToken,
            [FromQuery] int Page = 1, [FromQuery] int PageSize = 10)
        {
            var result = await Mediator.Send(new GetAllNotificationsQuery(Page, PageSize), cancellationToken);

            return Ok(result);
        }

        [HttpGet("GetById")]
        [AllowAnonymous]
        public async Task<ActionResult<NotificationDTO>> GetById(CancellationToken cancellationToken, [FromQuery] int Id = 0)
        {
            var result = await Mediator.Send(new FindNotificationByIdQuery(Id), cancellationToken);

            return Ok(result);
        }

        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<NotificationDTO>>> GetFilter([FromQuery] FilterNotificationsQuery query, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("DeleteAll")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteAll(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new DeleteAllNotificationsCommand(), cancellationToken);

            return Ok(result);
        }

        [HttpDelete("DeleteById")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteById(CancellationToken cancellationToken, [FromQuery] int Id = 0)
        {
            var result = await Mediator.Send(new DeleteNotificationByIdCommand(Id), cancellationToken);

            return Ok(result);
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<ActionResult> Update([FromBody] UpdateNotificationCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPut("Redirection")]
        [AllowAnonymous]
        public async Task<ActionResult> Redirection([FromBody] RedirectionToAnotherUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPost("Add")]
        [AllowAnonymous]
        public async Task<ActionResult> Add([FromBody] AddNotificationCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

    }
}
