using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WebApplication1.Models;

public class ServerContext: DbContext
{
    public DbSet<Kunde> Kunden { get; set; }
    public DbSet<Firma> Firma { get; set; }
    public DbSet<Produktgruppe> Produktgruppe { get; set; }
    public DbSet<MatchKundeProduktgruppe> MatchKundeProduktgruppe { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=serverdb.db");
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.NonTransactionalMigrationOperationWarning));
    }
}