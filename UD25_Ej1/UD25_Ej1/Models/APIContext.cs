using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UD25_Ej1.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            :base(options)
        {

        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("Articulo");

                entity.Property(c => c.Precio)
                    .IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired();

                entity.HasKey(c => c.Codigo);

                entity.HasOne(d => d.Fabricante)
                     .WithMany(p => p.Articulos)
                     .HasForeignKey(d => d.FabricanteID)
                     .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Fabricante>()
                .HasKey(c => c.Codigo);
        }
    }
}
