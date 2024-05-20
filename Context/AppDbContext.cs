using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WepApiGM.Models;

namespace WepApiGM.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Caseta> Caseta { get; set; }

    public virtual DbSet<Combustible> Combustibles { get; set; }

    public virtual DbSet<Ruta_caseta> RutaCaseta { get; set; }

    public virtual DbSet<Ruta> Ruta { get; set; }

    public virtual DbSet<Tarifa> Tarifa { get; set; }

    public virtual DbSet<Transporte> Transporte { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    public virtual DbSet<Viaje_ruta> ViajeRuta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0QASG6I\\SQLEXPRESS;Database=TravelGM;User=sa;Password=sysmaster;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caseta>(entity =>
        {
            entity.HasKey(e => e.IdCaseta).HasName("PK_caseta");

            entity.Property(e => e.IdCaseta).HasColumnName("idCaseta");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Combustible>(entity =>
        {
            entity.HasKey(e => e.IdCombustible).HasName("PK_combustible");

            entity.ToTable("Combustible");

            entity.Property(e => e.IdCombustible).HasColumnName("idCombustible");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Tipo)
                .HasColumnType("text")
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Ruta_caseta>(entity =>
        {
            entity.HasKey(e => e.IdRutaCaseta).HasName("PK_ruta_caseta");

            entity.ToTable("Ruta_caseta");

            entity.Property(e => e.IdRutaCaseta).HasColumnName("idRuta_Caseta");
            entity.Property(e => e.IdCaseta).HasColumnName("idCaseta");
            entity.Property(e => e.IdRuta).HasColumnName("idRuta");

            entity.HasOne(d => d.IdCasetaNavigation).WithMany(p => p.RutaCaseta)
                .HasForeignKey(d => d.IdCaseta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ruta_caseta_caseta");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.RutaCaseta)
                .HasForeignKey(d => d.IdRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ruta_caseta_ruta");
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.IdRuta).HasName("PK_ruta");

            entity.Property(e => e.IdRuta).HasColumnName("idRuta");
            entity.Property(e => e.Kilometros)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("kilometros");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.IdTarifa).HasName("PK_tarifa");

            entity.Property(e => e.IdTarifa).HasColumnName("idTarifa");
            entity.Property(e => e.IdCaseta).HasColumnName("idCaseta");
            entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.IdCasetaNavigation).WithMany(p => p.Tarifa)
                .HasForeignKey(d => d.IdCaseta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tarifa_caseta");

            entity.HasOne(d => d.IdTransporteNavigation).WithMany(p => p.Tarifa)
                .HasForeignKey(d => d.IdTransporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tarifa_transporte");
        });

        modelBuilder.Entity<Transporte>(entity =>
        {
            entity.HasKey(e => e.IdTransporte).HasName("PK_transporte");

            entity.ToTable("Transporte");

            entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");
            entity.Property(e => e.Ejes).HasColumnName("ejes");
            entity.Property(e => e.IdCombustible).HasColumnName("idCombustible");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");

            entity.HasOne(d => d.IdCombustibleNavigation).WithMany(p => p.Transporte)
                .HasForeignKey(d => d.IdCombustible)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_transporte_combustible");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Pass)
                .HasColumnType("text")
                .HasColumnName("pass");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.IdViaje).HasName("PK_viaje");

            entity.ToTable("Viaje");

            entity.Property(e => e.IdViaje).HasColumnName("idViaje");
            entity.Property(e => e.FechaPartida)
                .HasColumnType("datetime")
                .HasColumnName("fechaPartida");
            entity.Property(e => e.FechaRegreso)
                .HasColumnType("datetime")
                .HasColumnName("fechaRegreso");
            entity.Property(e => e.Pasajeros).HasColumnName("pasajeros");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.Viaticos).HasColumnName("viaticos");
        });

        modelBuilder.Entity<Viaje_ruta>(entity =>
        {
            entity.HasKey(e => e.IdViajeRuta).HasName("PK_viaje_ruta");

            entity.ToTable("Viaje_ruta");

            entity.Property(e => e.IdViajeRuta).HasColumnName("idViaje_Ruta");
            entity.Property(e => e.IdRuta).HasColumnName("idRuta");
            entity.Property(e => e.IdViaje).HasColumnName("idViaje");
            entity.Property(e => e.Ida).HasColumnName("ida");
            entity.Property(e => e.Regreso).HasColumnName("regreso");

            entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.ViajeRuta)
                .HasForeignKey(d => d.IdRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_viaje_ruta_ruta");

            entity.HasOne(d => d.IdViajeNavigation).WithMany(p => p.ViajeRuta)
                .HasForeignKey(d => d.IdViaje)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_viaje_ruta_viaje");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
