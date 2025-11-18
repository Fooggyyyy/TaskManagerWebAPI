using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Events.Querys.Querys.CommentQuerys;

namespace TaskManager_WebAPI.WebAPI.Controller
{
    [ApiController]
    [Route("API/Comment/")]
    public class CommentController(IMediator Mediator) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ICollection<CommentDTO>>> GetAll(CancellationToken cancellationToken, 
            [FromQuery] int Page = 1, [FromQuery] int PageSize = 10 )
        {
            var result =  await Mediator.Send(new GetAllCommentsQuery(Page, PageSize), cancellationToken);

            return Ok(result);
        }
    }
}
