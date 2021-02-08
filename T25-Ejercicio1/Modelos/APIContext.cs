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
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fabricante>()
                .HasKey(f => f.Codigo);
            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.ToTable("Fabricante");

                entity.Property(p => p.Codigo)
                      .HasColumnName("Codigo");

                entity.Property(p => p.Nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Articulo>()
              .HasKey(a => a.Codigo);
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("Articulo");

                entity.Property(a => a.Codigo)
                      .HasColumnName("Codigo");

                entity.Property(a => a.Nombre)
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(a => a.Precio)
                       .HasColumnName("Precio")
                      .IsRequired();

                entity.Property(a => a.FabricanteID)
                      .HasColumnName("Fabricante ID")
                .IsRequired();

                entity.HasOne(a => a.Fabricantes)
                      .WithMany(f => f.Articulos)
                      .HasForeignKey(a => a.FabricanteID)
                      .OnDelete(DeleteBehavior.ClientSetNull);                        
            });
        }
    }
}