using Microsoft.EntityFrameworkCore;
using Paginacao.Models;

namespace Paginacao.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo> ?Todos {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_BM");
        if (conexao is null) conexao = "Server=localhost;Database=estoque;Uid=root;Pwd='';";
        optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
    }
}