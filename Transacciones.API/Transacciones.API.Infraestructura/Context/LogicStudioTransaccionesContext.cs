using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Transacciones.API.Entidades.Entities;


namespace Transacciones.API.Infraestructura.Context;

public partial class LogicStudioTransaccionesContext : DbContext
{
    public LogicStudioTransaccionesContext()
    {
    }

    public LogicStudioTransaccionesContext(DbContextOptions<LogicStudioTransaccionesContext> options)
        : base(options)
    {
    }

    public  DbSet<TBL_PRODUCTO> TBL_PRODUCTO { get; set; }

    public  DbSet<TBL_TRANSACCIONE> TBL_TRANSACCIONE { get; set; }

    public DbSet<TBL_USUARIO> TBL_USUARIOS { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //SGA:
        // quito la cadena de conexion a la base que estaba quemada 
        // Cuando se registra el contextDB de LogicStudioTransaccionesContext en Program.cs
        // se va a usar esa configuracion centralizada, mas limpia y segura.

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TBL_PRODUCTO>(entity =>
        {
            entity.HasKey(e => e.ID_PRODUCTO).HasName("PK__TBL_PROD__88BD035758D4EB13");
            entity.ToTable("TBL_PRODUCTOS");
           /* entity.Property(e => e.CATEGORIA_PRODUCTO)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DESCRIPCION_PRODUCTO)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NOMBRE_PRODUCTO)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.PRECIO).HasColumnType("decimal(10, 2)"); */
        });

        modelBuilder.Entity<TBL_TRANSACCIONE>(entity =>
        {
            entity.HasKey(e => e.ID_TRX).HasName("PK__TBL_TRAN__27BF9940C76C99E4");

            entity.ToTable("TBL_TRANSACCIONES");

            entity.HasIndex(e => e.ID_PRODUCTO, "IDX_TBL_TRANSACCIONES_ID_PRODUCTO");

            entity.Property(e => e.ID_TRX)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DETALLE_TRX)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PRECIO_TOTAL).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PRECIO_UNITARIO).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TIPO_TRX)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.ID_PRODUCTONavigation).WithMany(p => p.TBL_TRANSACCIONEs)
                .HasForeignKey(d => d.ID_PRODUCTO)
                .HasConstraintName("FK_TBL_TRX");
        });

        modelBuilder.Entity<TBL_USUARIO>(entity =>
        {
            entity.HasKey(e => e.id_usuario);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");

            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .HasColumnName("ESTADO");

            entity.Property(e => e.Rol)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("ROL");

            entity.ToTable("TBL_USUARIOS");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
