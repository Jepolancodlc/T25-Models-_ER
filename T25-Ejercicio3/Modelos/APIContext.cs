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
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Almacen> Almacens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>()
                .HasKey(f => f.Codigo);
            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.ToTable("Almacen");
                entity.Property(p => p.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(p => p.lugar)
                      .IsRequired()
                      .HasColumnName("Lugar")

                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.capacidad);
            });

            modelBuilder.Entity<Caja>()
              .HasKey(a => a.NumReferencia);
            modelBuilder.Entity<Caja>(entity =>
            {
                entity.ToTable("Caja");
                entity.Property(a => a.NumReferencia)
                      .HasColumnName("Num Referencia");
                entity.Property(a => a.Contenido)
                      .IsRequired()
                      .HasColumnName("Contenido")
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.Valor)
                    .HasColumnName("Valor")
                      .HasColumnType("decimal(10,2)");
                entity.Property(a => a.AlmacenID)
                      .HasColumnName("ID Almacen");
                entity.HasOne(a => a.Almacen)
                      .WithMany(f => f.Cajas)
                      .HasForeignKey(a => a.AlmacenID)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

        }
    }
}