using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application;
using Blog.Application.Commands;
using Blog.Application.DataTransfer;
using Blog.Application.Queries;
using Blog.Application.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public ArticlesController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/<ArticlesController>
        [HttpGet]
      
        public IActionResult Get([FromQuery] ArticlesSearch search, [FromServices] IGetArticlesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneArticleQuery queryOne)
        {
            return Ok(executor.ExecuteQuery(queryOne, id));
        }

        // POST api/<ArticlesController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] CreateArticleDto dto, [FromServices] ICreateArticleCommand command)
        {
            executor.ExecuteCommand(command, dto);

        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] ArticlesDto dto, [FromServices] IUpdateArticleCommand command)
        {
            executor.ExecuteCommandUpdate(command, dto, id);
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteArticleCommand command)
        {
            executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
