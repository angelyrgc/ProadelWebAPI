using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProadelWebAPI.Models
{
    public partial class PROADELContext : DbContext
    {
        public PROADELContext()
        {
        }

        public PROADELContext(DbContextOptions<PROADELContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatalogoClientesDatum> CatalogoClientesData { get; set; } = null!;
        public virtual DbSet<LoginAccessDatum> LoginAccessData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PROADEL;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogoClientesDatum>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("CATALOGO_CLIENTES_DATA", "proadel");

                entity.Property(e => e.Codigo).HasMaxLength(10);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.LimiteDeCredito)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Limite de credito");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<LoginAccessDatum>(entity =>
            {
                entity.ToTable("LOGIN_ACCESS_DATA", "proadel");

                entity.Property(e => e.InsertionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Insertion Date");

                entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modification Date");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Permiso).HasMaxLength(10);

                entity.Property(e => e.Usuario).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
