using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace UD25_Ej2.Models
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
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");

                entity.Property(c => c.Nombre)
                      .IsRequired();

                entity.Property(e => e.Apellidos)
                      .IsRequired();

                entity.HasKey(f => f.DNI);

                entity.HasOne(d => d.Departamento)
                      .WithMany(p => p.Empleados)
                      .HasForeignKey(d => d.DepartamentoID)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Departamento>()
                .HasKey(c => c.Codigo);
        }
    }
}
