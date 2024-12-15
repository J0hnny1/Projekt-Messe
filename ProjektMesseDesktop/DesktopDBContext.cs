using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication1.Models;

namespace ProjektMesseDesktop;

public class DesktopDbContext: DbContext
{
    public DbSet<Kunde> Kunden { get; set; }
    public DbSet<Firma> Firma { get; set; }
    public DbSet<Produktgruppe> Produktgruppe { get; set; }
    public DbSet<MatchKundeProduktgruppe> MatchKundeProduktgruppe { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=desktop.dat");
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.NonTransactionalMigrationOperationWarning));
        optionsBuilder.UseLazyLoadingProxies();

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kunde>().ToTable("Kunden");
    }
}