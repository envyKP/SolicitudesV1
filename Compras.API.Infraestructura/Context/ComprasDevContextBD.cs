using System;
using System.Collections.Generic;
using Compras.API.Entidades.Entities;
using Microsoft.EntityFrameworkCore;

namespace Compras.API.Infraestructura.Context;

public partial class ComprasDevContextBD : DbContext
{
    public ComprasDevContextBD()
    {
    }

    public ComprasDevContextBD(DbContextOptions<ComprasDevContextBD> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditorium> auditoria { get; set; }

    public virtual DbSet<Role> roles { get; set; }

    public virtual DbSet<Solicitude> solicitudes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__auditori__3213E83F1815FFBD");

            entity.Property(e => e.datos_anteriores).IsUnicode(false);
            entity.Property(e => e.datos_nuevos).IsUnicode(false);
            entity.Property(e => e.fecha_operacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.tabla_afectada)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.tipo_operacion)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.auditoria)
                .HasForeignKey(d => d.id)
                .HasConstraintName("FK__auditoria__usuar__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.rol_id).HasName("PK__roles__CF32E443404FDB56");

            entity.Property(e => e.descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.fecha_creacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__solicitu__3213E83FBB769796");

            entity.ToTable(tb => tb.HasTrigger("tr_solicitudes_auditoria"));

            entity.Property(e => e.comentario)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.monto).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Usuarios__3213E83F5AF56A2D");

            entity.ToTable(tb => tb.HasTrigger("tr_Usuarios_auditoria"));

            entity.HasIndex(e => e.username, "UQ__Usuarios__F3DBC572AE8F75A2").IsUnique();

            entity.Property(e => e.correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.rol).WithMany(p => p.usuarios)
                .HasForeignKey(d => d.rol_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__rol_id__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
