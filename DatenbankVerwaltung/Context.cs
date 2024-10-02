using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class Context: DbContext
{
    public DbSet<Kunde> Kunden { get; set; }
    public DbSet<Firma> Firma { get; set; }
    public DbSet<Produktgruppe> Produktgruppe { get; set; }
    //public string DbPath { get; }

    public Context()
    {
        //Console.WriteLine("Path: ", dbName);
        //this.DbPath = dbName;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=serverdb.db");
    }
}