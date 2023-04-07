using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paginacao.Data;
using Paginacao.Models;

namespace Paginacao.Controllers;

[ApiController]
[Route(template:"v1todos")]
public class TodoController : ControllerBase
{
    [HttpGet(template: "load")]
    public async Task<IActionResult> LoadAsync(
        [FromServices]AppDbContext context)
        {
            for(var i = 0; i <1348; i++){
                var todo = new Todo(){
                    Id = i +1,
                    Done = false,
                    CreatedAt = DateTime.Now,
                    Title = $"Tarefa{i}"
                };
                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
        [HttpGet(template:"{skip}/{take}")]
        public async Task<IActionResult>GetAsync([FromServices]AppDbContext context, 
        [FromRoute] int skip = 0, [FromRoute] int take = 25)
        {
            var total = await context.Todos.CountAsync(); //conta todos os elementos do banco
            var todos = await context.Todos.AsNoTracking().Skip(skip).Take(take).ToListAsync();

            return Ok(new{total, data = todos});
        }
}