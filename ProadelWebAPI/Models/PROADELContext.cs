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

        public virtual DbSet<CatalogoClientesV> CatalogoClientesVs { get; set; } = null!;
        public virtual DbSet<ImporteFacturacionClientesV> ImporteFacturacionClientesVs { get; set; } = null!;
        public virtual DbSet<LoginAccessDatum> LoginAccessData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PROADEL;Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogoClientesV>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CATALOGO_CLIENTES_V", "proadel");

                entity.Property(e => e.Abono)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("ABONO");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(225)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IMPORTE");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(225)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.SaldoTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SALDO_TOTAL");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("TELEFONO");
            });

            modelBuilder.Entity<ImporteFacturacionClientesV>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("IMPORTE_FACTURACION_CLIENTES_V", "proadel");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(50)
                    .HasColumnName("CLIENTE");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(38, 2)")
                    .HasColumnName("TOTAL");
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
