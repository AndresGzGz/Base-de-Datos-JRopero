using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppEstudiantes588.Modelo
{
    public partial class bd_estudiantesContext : DbContext
    {
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost; userid=root; password=; Database=bd-estudiantes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable<Estudiantes>("estudiantes");

                entity.Property(e => e.Codigo).HasColumnType("int(4)");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });
        }
    }
}
