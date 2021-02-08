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
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>()
                .HasKey(f => f.Codigo);
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamento");
                entity.Property(p => p.Codigo)
                      .HasColumnName("Codigo");
                entity.Property(p => p.Nombre)
                      .HasColumnName("Nombre")
                      .IsRequired()
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.Presupuesto)
                .HasColumnName("Presupuesto");
            });

            modelBuilder.Entity<Empleado>()
              .HasKey(a => a.DNI);
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");
                entity.Property(a => a.DNI)
                      .HasColumnName("DNI");
                entity.Property(a => a.Nombre)
                      .IsRequired()
                      .HasColumnName("Nombre")
                      .HasMaxLength(100)
                      .IsUnicode(false);
                entity.Property(a => a.Apellidos)
                      .IsRequired()
                      .HasColumnName("Apellidos")
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(a => a.DepartamentoID)
                      .HasColumnName("Id departameantos");
                entity.HasOne(a => a.Departamento)
                      .WithMany(f => f.Empleados)
                      .HasForeignKey(a => a.DepartamentoID)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}