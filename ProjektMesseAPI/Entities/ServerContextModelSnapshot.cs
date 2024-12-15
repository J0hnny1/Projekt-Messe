﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

#nullable disable

namespace ProjektMesseAPI.Entities
{
    [DbContext(typeof(ServerContext))]
    partial class ServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1");

            modelBuilder.Entity("WebApplication1.Models.Firma", b =>
                {
                    b.Property<int>("FirmaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PLZ")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Stadt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Straße")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FirmaID");

                    b.ToTable("Firma");
                });

            modelBuilder.Entity("WebApplication1.Models.Kunde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Bild")
                        .HasColumnType("BLOB");

                    b.Property<int?>("FirmaID")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Firmenberater")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Geburtstag")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PLZ")
                        .HasColumnType("TEXT");

                    b.Property<string>("Stadt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Straße")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vorname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FirmaID");

                    b.ToTable("Kunden");
                });

            modelBuilder.Entity("WebApplication1.Models.MatchKundeProduktgruppe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("KundeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProduktgruppenID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("KundeId");

                    b.HasIndex("ProduktgruppenID");

                    b.ToTable("MatchKundeProduktgruppe");
                });

            modelBuilder.Entity("WebApplication1.Models.Produktgruppe", b =>
                {
                    b.Property<int>("ProduktgruppenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProduktgruppenID");

                    b.ToTable("Produktgruppe");
                });

            modelBuilder.Entity("WebApplication1.Models.Kunde", b =>
                {
                    b.HasOne("WebApplication1.Models.Firma", "Firma")
                        .WithMany()
                        .HasForeignKey("FirmaID");

                    b.Navigation("Firma");
                });

            modelBuilder.Entity("WebApplication1.Models.MatchKundeProduktgruppe", b =>
                {
                    b.HasOne("WebApplication1.Models.Kunde", "Kunde")
                        .WithMany()
                        .HasForeignKey("KundeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Produktgruppe", "Produktgruppe")
                        .WithMany()
                        .HasForeignKey("ProduktgruppenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kunde");

                    b.Navigation("Produktgruppe");
                });
#pragma warning restore 612, 618
        }
    }
}
