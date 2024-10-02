using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class ServerContext: DbContext
{
    public DbSet<Kunde> Kunden { get; set; }
    public DbSet<Firma> Firma { get; set; }
    public DbSet<Produktgruppe> Produktgruppe { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=serverdb.db");
    }
}