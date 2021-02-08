using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UD25_Ej3.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {

        }

        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Caja> Cajas { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caja>(entity =>
            {
                entity.ToTable("Caja");

                entity.Property(c => c.Contenido)
                      .IsRequired();

                entity.Property(e => e.Valor)
                      .IsRequired();

                entity.HasKey(f => f.NumReferencia);

                entity.HasOne(d => d.Almacen)
                      .WithMany(p => p.Cajas)
                      .HasForeignKey(d => d.AlmacenID)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Almacen>()
                .HasKey(c => c.Codigo);
        }
    }
}
