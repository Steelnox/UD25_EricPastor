using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UD25_Ej4.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {

        }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Sala");
                entity.Property(c => c.Nombre)
                      .IsRequired();

                entity.HasKey(e => e.Codigo);

                entity.HasOne(d => d.Pelicula)
                      .WithMany(p => p.Salas)
                      .HasForeignKey(d => d.PeliculaID)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Pelicula>()
                .HasKey(c => c.Codigo);
        }
    }
}
