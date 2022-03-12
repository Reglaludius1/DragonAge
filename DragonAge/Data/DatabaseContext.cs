using DragonAge.Models;
using Microsoft.EntityFrameworkCore;

namespace DragonAge.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Codex> Codices { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=DragonAge.db");
    }
}