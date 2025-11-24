using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Commands.Commands.CommentCommands;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.LayerQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.UserQuerys;

namespace TaskManager_WebAPI.WebAPI.Controller
{
    [ApiController]
    [Route("API/User/")]
    public class UserController(IMediator Mediator) : ControllerBase
    {
        [HttpGet("All")]
        [Authorize]
        public async Task<ActionResult<ICollection<UserDTO>>> GetAll(CancellationToken cancellationToken,
            [FromQuery] int Page = 1, [FromQuery] int PageSize = 10)
        {
            var result = await Mediator.Send(new GetAllUsersQuery(Page, PageSize), cancellationToken);

            return Ok(result);
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetById(CancellationToken cancellationToken, [FromQuery] int Id = 0)
        {
            var result = await Mediator.Send(new FindUserByIdQuery(Id), cancellationToken);

            return Ok(result);
        }

        [HttpGet("Filter")]
        [Authorize]
        public async Task<ActionResult<ICollection<UserDTO>>> GetFilter([FromQuery] FilterUsersQuery query, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("DeleteAll")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> DeleteAll(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new DeleteAllUsersCommand(), cancellationToken);

            return Ok(result);
        }

        [HttpDelete("DeleteById")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> DeleteById(CancellationToken cancellationToken, [FromQuery] int Id = 0)
        {
            var result = await Mediator.Send(new DeleteUserByIdCommand(Id), cancellationToken);

            return Ok(result);
        }

        [HttpPut("Update")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<object>> Update([FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPost("Add")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<object>> Add([FromBody] AddUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        //Auth Controller
        [HttpDelete("Exit")]
        [Authorize]
        public async Task<ActionResult> Exit(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new ExitUserCommand(), cancellationToken);

            return Ok(result);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Login([FromBody] LoginUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Register([FromBody] RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPost("Reset")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Reset([FromBody] ResetPasswordUserCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
