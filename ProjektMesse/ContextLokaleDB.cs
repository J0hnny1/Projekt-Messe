using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication1.Models;

using WebApplication1.Models;

namespace ProjektMesse;

public class ContextLokaleDB : DbContext
{
    public DbSet<Kunde> Kunden { get; set; }
    public DbSet<Firma> Firma { get; set; }
    public DbSet<Produktgruppe> Produktgruppe { get; set; }
    public DbSet<MatchKundeProduktgruppe> MatchKundeProduktgruppe { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite("Data Source=databse.dat");
        var projectRootPath = System.IO.Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,"MesseLokal.db");
        optionsBuilder.UseSqlite($"Data Source={projectRootPath}");
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.NonTransactionalMigrationOperationWarning));
    }
}