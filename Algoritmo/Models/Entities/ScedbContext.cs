using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Algoritmo.Models.Entities;

public partial class ScedbContext : DbContext
{
    public ScedbContext()
    {
    }

    public ScedbContext(DbContextOptions<ScedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AreaAcademica> AreaAcademica { get; set; }

    public virtual DbSet<Aula> Aula { get; set; }

    public virtual DbSet<Carrera> Carrera { get; set; }

    public virtual DbSet<CarreraConEdificio> CarreraConEdificio { get; set; }

    public virtual DbSet<Configuracion> Configuracion { get; set; }

    public virtual DbSet<Edificio> Edificio { get; set; }

    public virtual DbSet<Examen> Examen { get; set; }

    public virtual DbSet<Fecha> Fecha { get; set; }

    public virtual DbSet<FechaConHora> FechaConHora { get; set; }

    public virtual DbSet<Grupo> Grupo { get; set; }

    public virtual DbSet<Hora> Hora { get; set; }

    public virtual DbSet<Maestro> Maestro { get; set; }

    public virtual DbSet<Materia> Materia { get; set; }

    public virtual DbSet<Periodo> Periodo { get; set; }

    public virtual DbSet<TipoAula> TipoAula { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=websitos256.com;password=bN9w&988v;database=scedb;user=websitos_sce_admin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.7-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<AreaAcademica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("area_academica")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("aula")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.EdificioId, "EDIFICIO_ID");

            entity.HasIndex(e => e.TipoAulaId, "TIPO_AULA_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Clave)
                .HasMaxLength(255)
                .HasColumnName("CLAVE");
            entity.Property(e => e.EdificioId)
                .HasColumnType("int(11)")
                .HasColumnName("EDIFICIO_ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.TipoAulaId)
                .HasColumnType("int(11)")
                .HasColumnName("TIPO_AULA_ID");

            entity.HasOne(d => d.Edificio).WithMany(p => p.Aula)
                .HasForeignKey(d => d.EdificioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aula_ibfk_2");

            entity.HasOne(d => d.TipoAula).WithMany(p => p.Aula)
                .HasForeignKey(d => d.TipoAulaId)
                .HasConstraintName("aula_ibfk_1");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("carrera")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Letra)
                .HasMaxLength(2)
                .HasColumnName("LETRA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<CarreraConEdificio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("carrera_con_edificio")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.CarreraId, "CARRERA_ID");

            entity.HasIndex(e => e.EdificioId, "EDIFICIO_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CarreraId)
                .HasColumnType("int(11)")
                .HasColumnName("CARRERA_ID");
            entity.Property(e => e.EdificioId)
                .HasColumnType("int(11)")
                .HasColumnName("EDIFICIO_ID");

            entity.HasOne(d => d.Carrera).WithMany(p => p.CarreraConEdificio)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carrera_con_edificio_ibfk_1");

            entity.HasOne(d => d.Edificio).WithMany(p => p.CarreraConEdificio)
                .HasForeignKey(d => d.EdificioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carrera_con_edificio_ibfk_2");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("configuracion")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("CONTRASENA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Edificio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("edificio")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Examen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("examen")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.AulaId, "AULA_ID");

            entity.HasIndex(e => e.FechaConHoraId, "FECHA_CON_HORA_ID");

            entity.HasIndex(e => e.GrupoId, "GRUPO_ID");

            entity.HasIndex(e => e.PeriodoId, "PERIODO_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AulaId)
                .HasColumnType("int(11)")
                .HasColumnName("AULA_ID");
            entity.Property(e => e.FechaConHoraId)
                .HasColumnType("int(11)")
                .HasColumnName("FECHA_CON_HORA_ID");
            entity.Property(e => e.GrupoId)
                .HasColumnType("int(11)")
                .HasColumnName("GRUPO_ID");
            entity.Property(e => e.PeriodoId)
                .HasColumnType("int(11)")
                .HasColumnName("PERIODO_ID");

            entity.HasOne(d => d.Aula).WithMany(p => p.Examen)
                .HasForeignKey(d => d.AulaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("examen_ibfk_2");

            entity.HasOne(d => d.FechaConHora).WithMany(p => p.Examen)
                .HasForeignKey(d => d.FechaConHoraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("examen_ibfk_4");

            entity.HasOne(d => d.Grupo).WithMany(p => p.Examen)
                .HasForeignKey(d => d.GrupoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("examen_ibfk_1");

            entity.HasOne(d => d.Periodo).WithMany(p => p.Examen)
                .HasForeignKey(d => d.PeriodoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("examen_ibfk_3");
        });

        modelBuilder.Entity<Fecha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("fecha")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.PeriodoId, "PERIODO_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.PeriodoId)
                .HasColumnType("int(11)")
                .HasColumnName("PERIODO_ID");

            entity.HasOne(d => d.Periodo).WithMany(p => p.Fecha)
                .HasForeignKey(d => d.PeriodoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fecha_ibfk_1");
        });

        modelBuilder.Entity<FechaConHora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("fecha_con_hora")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.FechaId, "FECHA_ID");

            entity.HasIndex(e => e.HoraId, "HORA_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.FechaId)
                .HasColumnType("int(11)")
                .HasColumnName("FECHA_ID");
            entity.Property(e => e.HoraId)
                .HasColumnType("int(11)")
                .HasColumnName("HORA_ID");

            entity.HasOne(d => d.Fecha).WithMany(p => p.FechaConHora)
                .HasForeignKey(d => d.FechaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fecha_con_hora_ibfk_2");

            entity.HasOne(d => d.Hora).WithMany(p => p.FechaConHora)
                .HasForeignKey(d => d.HoraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fecha_con_hora_ibfk_1");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("grupo")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.CarreraId, "CARRERA_ID");

            entity.HasIndex(e => e.MaestroId, "MAESTRO_ID");

            entity.HasIndex(e => e.MateriaId, "MATERIA_ID");

            entity.HasIndex(e => e.PeriodoId, "PERIODO_ID");

            entity.HasIndex(e => e.GrupoCompartidoId, "grupo_ibfk_4");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Aula)
                .HasMaxLength(255)
                .HasColumnName("AULA");
            entity.Property(e => e.Bloque)
                .HasMaxLength(45)
                .HasDefaultValueSql("'Matutino'");
            entity.Property(e => e.CarreraId)
                .HasColumnType("int(11)")
                .HasColumnName("CARRERA_ID");
            entity.Property(e => e.GrupoCompartidoId)
                .HasColumnType("int(11)")
                .HasColumnName("GRUPO_COMPARTIDO_ID");
            entity.Property(e => e.MaestroId)
                .HasColumnType("int(11)")
                .HasColumnName("MAESTRO_ID");
            entity.Property(e => e.MateriaId)
                .HasColumnType("int(11)")
                .HasColumnName("MATERIA_ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PeriodoId)
                .HasColumnType("int(11)")
                .HasColumnName("PERIODO_ID");
            entity.Property(e => e.TieneExamen)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("TIENE_EXAMEN");

            entity.HasOne(d => d.Carrera).WithMany(p => p.Grupo)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupo_ibfk_5");

            entity.HasOne(d => d.GrupoCompartido).WithMany(p => p.InverseGrupoCompartido)
                .HasForeignKey(d => d.GrupoCompartidoId)
                .HasConstraintName("grupo_ibfk_4");

            entity.HasOne(d => d.Maestro).WithMany(p => p.Grupo)
                .HasForeignKey(d => d.MaestroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupo_ibfk_1");

            entity.HasOne(d => d.Materia).WithMany(p => p.Grupo)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupo_ibfk_3");

            entity.HasOne(d => d.Periodo).WithMany(p => p.Grupo)
                .HasForeignKey(d => d.PeriodoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("grupo_ibfk_2");
        });

        modelBuilder.Entity<Hora>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hora")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Maestro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("maestro")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.AreaAcademicaId, "AREA_ACADEMICA_ID");

            entity.HasIndex(e => e.Rfc, "RFC_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AreaAcademicaId)
                .HasColumnType("int(11)")
                .HasColumnName("AREA_ACADEMICA_ID");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE_COMPLETO");
            entity.Property(e => e.Numerocontrol)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("NUMEROCONTROL");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .HasColumnName("RFC");

            entity.HasOne(d => d.AreaAcademica).WithMany(p => p.Maestro)
                .HasForeignKey(d => d.AreaAcademicaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("maestro_ibfk_1");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("materia")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.Clave, "CLAVE_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Clave)
                .HasMaxLength(7)
                .HasColumnName("CLAVE");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("periodo")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<TipoAula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tipo_aula")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
