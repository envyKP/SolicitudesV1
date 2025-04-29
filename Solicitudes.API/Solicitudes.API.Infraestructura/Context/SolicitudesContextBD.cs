using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Solicitudes.API.Entidades.Entities;

namespace Solicitudes.API.Infraestructura.Context;

public partial class SolicitudesContextBD : DbContext
{
    public SolicitudesContextBD()
    {
    }

    public SolicitudesContextBD(DbContextOptions<SolicitudesContextBD> options)
        : base(options)
    {
    }

    public DbSet<TBL_AUDITORIA> TBL_AUDITORIA { get; set; }
    public DbSet<TBL_ROL> TBL_ROL { get; set; }
    public DbSet<TBL_SOLICITUD> TBL_SOLICITUD { get; set; }
    public DbSet<TBL_USUARIO> TBL_USUARIO { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // No colocar la cadena de conexión aquí. Se pasa desde Program.cs o Startup.cs para mantenerlo seguro.
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TBL_AUDITORIA>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("TBL_AUDITORIA");

            entity.Property(e => e.TABLA_AFECTADA)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.TIPO_OPERACION)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FECHA_OPERACION)
                .HasColumnType("datetime");

            entity.Property(e => e.DATOS_ANTERIORES)
                .HasColumnType("nvarchar(max)");

            entity.Property(e => e.DATOS_NUEVOS)
                .HasColumnType("nvarchar(max)");

            entity.HasOne(d => d.TBL_USUARIO)
                .WithMany(p => p.TBL_AUDITORIAS)
                .HasForeignKey(d => d.USUARIO_ID)
                .HasConstraintName("FK_TBL_AUDITORIA_TBL_USUARIO");
        });

        modelBuilder.Entity<TBL_ROL>(entity =>
        {
            entity.HasKey(e => e.ROL_ID);
            entity.ToTable("TBL_ROLES");

            entity.Property(e => e.DESCRIPCION)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FECHA_CREACION)
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TBL_SOLICITUD>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("TBL_SOLICITUDES");

            entity.Property(e => e.DESCRIPCION)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.MONTO)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.FECHA_ESPERADA)
                .HasColumnType("datetime");

            entity.Property(e => e.ESTADO)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.COMENTARIO)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TBL_USUARIO>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.ToTable("TBL_USUARIOS");

            entity.Property(e => e.NOMBRES)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.USERNAME)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.CLAVE)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.CORREO)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.TBL_ROL)
                .WithMany(p => p.TBL_USUARIOS)
                .HasForeignKey(d => d.ROL_ID)
                .HasConstraintName("FK_TBL_USUARIO_TBL_ROL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
