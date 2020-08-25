using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public CommentsController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // POST api/<CommentsController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] CommentsDto dto, [FromServices] ICreateCommentCommand command)
        {
            executor.ExecuteCommand(command, dto);

        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] UpdateCommentsDto dto, [FromServices] IUpdateCommentCommand command)
        {
            executor.ExecuteCommandUpdate(command, dto, id);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
