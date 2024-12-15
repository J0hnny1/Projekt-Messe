using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjektMesse.Models;

public partial class DatabseContext : DbContext
{
    public DatabseContext()
    {
    }

    public DatabseContext(DbContextOptions<DatabseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EfmigrationsLock> EfmigrationsLocks { get; set; }

    public virtual DbSet<Firma> Firmas { get; set; }

    public virtual DbSet<Kunden> Kundens { get; set; }

    public virtual DbSet<MatchKundeProduktgruppe> MatchKundeProduktgruppes { get; set; }

    public virtual DbSet<Produktgruppe> Produktgruppe { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=databse.dat");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfmigrationsLock>(entity =>
        {
            entity.ToTable("__EFMigrationsLock");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Firma>(entity =>
        {
            entity.ToTable("Firma");

            entity.Property(e => e.FirmaId).HasColumnName("FirmaID");
            entity.Property(e => e.Plz).HasColumnName("PLZ");
        });

        modelBuilder.Entity<Kunden>(entity =>
        {
            entity.ToTable("Kunden");

            entity.HasIndex(e => e.FirmaId, "IX_Kunden_FirmaID");

            entity.Property(e => e.FirmaId).HasColumnName("FirmaID");
            entity.Property(e => e.Plz).HasColumnName("PLZ");

            entity.HasOne(d => d.Firma).WithMany(p => p.Kundens).HasForeignKey(d => d.FirmaId);
        });

        modelBuilder.Entity<MatchKundeProduktgruppe>(entity =>
        {
            entity.ToTable("MatchKundeProduktgruppe");

            entity.HasIndex(e => e.KundeId, "IX_MatchKundeProduktgruppe_KundeId");

            entity.HasIndex(e => e.ProduktgruppenId, "IX_MatchKundeProduktgruppe_ProduktgruppenID");

            entity.Property(e => e.ProduktgruppenId).HasColumnName("ProduktgruppenID");

            entity.HasOne(d => d.Kunde).WithMany(p => p.MatchKundeProduktgruppes).HasForeignKey(d => d.KundeId);

            entity.HasOne(d => d.Produktgruppen).WithMany(p => p.MatchKundeProduktgruppes).HasForeignKey(d => d.ProduktgruppenId);
        });

        modelBuilder.Entity<Produktgruppe>(entity =>
        {
            entity.HasKey(e => e.ProduktgruppenId);

            entity.ToTable("Produktgruppe");

            entity.Property(e => e.ProduktgruppenId).HasColumnName("ProduktgruppenID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
