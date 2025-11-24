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
using TaskManager_Application.Application.Events.Commands.Commands.LayerCommands;
using TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys;
using TaskManager_Application.Application.Events.Querys.Querys.LayerQuerys;

namespace TaskManager_WebAPI.WebAPI.Controller
{
    [ApiController]
    [Route("API/Layer/")]
    public class LayerController(IMediator Mediator) : ControllerBase
    {
        [HttpGet("All")]
        [Authorize]
        public async Task<ActionResult<ICollection<LayerDTO>>> GetAll(CancellationToken cancellationToken,
            [FromQuery] int Page = 1, [FromQuery] int PageSize = 10)
        {
            var result = await Mediator.Send(new GetAllLayersQuery(Page, PageSize), cancellationToken);

            return Ok(result);
        }

        [HttpGet("GetById")]
        [Authorize]
        public async Task<ActionResult<LayerDTO>> GetById(CancellationToken cancellationToken, [FromQuery] int Id = 0)
        {
            var result = await Mediator.Send(new FindLayerByIdQuery(Id), cancellationToken);

            return Ok(result);
        }

        [HttpGet("Filter")]
        [Authorize]
        public async Task<ActionResult<ICollection<LayerDTO>>> GetFilter([FromQuery] FilterLayersQuery query, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("DeleteAll")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> DeleteAll(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new DeleteAllLayersCommand(), cancellationToken);

            return Ok(result);
        }

        [HttpDelete("DeleteById")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> DeleteById(CancellationToken cancellationToken, [FromQuery] int Id = 0)
        {
            var result = await Mediator.Send(new DeleteLayerByIdCommand(Id), cancellationToken);

            return Ok(result);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Developer,ProjectManager,Admin")]
        public async Task<ActionResult> Update([FromBody] UpdateLayerCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Developer,ProjectManager,Admin")]
        public async Task<ActionResult> Add([FromBody] AddLayerCommand command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
