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
using TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands;
using TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.LayerQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.ProjectQuerys;

namespace TaskManager_WebAPI.WebAPI.Controller
{
    [ApiController]
    [Route("API/Project/")]
    public class ProjectController(IMediator Mediator) : ControllerBase
    {
        [HttpGet("All")]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<ProjectDTO>>> GetAll(CancellationToken cancellationToken,
            [FromQuery] int Page = 1, [FromQuery] int PageSize = 10)
        {
            var result = await Mediator.Send(new GetAllProjectsQuery(Page, PageSize), cancellationToken);

            return Ok(result);
        }

        [HttpGet("GetById")]
        [AllowAnonymous]
        public async Task<ActionResult<ProjectDTO>> GetById(CancellationToken cancellationToken, [FromQuery] int Id = 0)
        {
            var result = await Mediator.Send(new FindProjectByIdQuery(Id), cancellationToken);

            return Ok(result);
        }

        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<ProjectDTO>>> GetFilter([FromQuery] FilterProjectsQuery query, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("DeleteAll")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteAll(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new DeleteAllProjectsCommand(), cancellationToken);

            return Ok(result);
        }

        [HttpDelete("DeleteById")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteById(CancellationToken cancellationToken, [FromQuery] int Id = 0)
        {
            var result = await Mediator.Send(new DeleteProjectByIdCommand(Id), cancellationToken);

            return Ok(result);
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        public async Task<ActionResult> Update([FromBody] UpdateProjectCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPost("Add")]
        [AllowAnonymous]
        public async Task<ActionResult> Add([FromBody] AddProjectCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
