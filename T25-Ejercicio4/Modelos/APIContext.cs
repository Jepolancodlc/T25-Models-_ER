using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T24_Ejercici1.Modelos;

namespace T24_Ejercici1.Modelos
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
        : base(options)
        {

        }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>()
                .HasKey(f => f.Codigo);
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("Pelicula");

                entity.Property(p => p.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .HasColumnName("Nombre");
            });

            modelBuilder.Entity<Sala>()
              .HasKey(a => a.Codigo);
            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Salas");
                entity.Property(a => a.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(a => a.Nombre)
                      .IsRequired()
                       .HasColumnName("Nombre")
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.PeliculaID)
                      .HasColumnName("ID Pelicula");
                entity.HasOne(a => a.Peliculas)
                    .WithMany(f => f.salas)
                    .HasForeignKey(a => a.PeliculaID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

        }
    } 
}