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
        [FromRoute] int skip, [FromRoute] int take)
        { 
            var total = await context.Todos.CountAsync(); //conta todos os elementos do banco
            var todos = await context.Todos.AsNoTracking().Skip(skip).Take(take).ToListAsync();
            var totalPag = await context.Todos.Skip(skip).Take(take).CountAsync(); //total de itens da pagina
            if(skip == 0 & take ==0){
                return Ok(new{total, data = context.Todos});
            }

            return Ok(new{totalPag, data = todos});
        }
}