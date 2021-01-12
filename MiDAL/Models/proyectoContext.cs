using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MiDAL.Models
{
    public partial class proyectoContext : DbContext
    {
        public proyectoContext()
        {
        }

        public proyectoContext(DbContextOptions<proyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Concesionario> Concesionario { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Piezas> Piezas { get; set; }
        public virtual DbSet<Piezasrep> Piezasrep { get; set; }
        public virtual DbSet<Ppto> Ppto { get; set; }
        public virtual DbSet<Repara> Repara { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=usuario_hibernate;password=1234;database=proyecto");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCli)
                    .HasName("PRIMARY");

                entity.ToTable("clientes");

                entity.HasIndex(e => e.Dni)
                    .HasName("DNI")
                    .IsUnique();

                entity.HasIndex(e => e.IdCli)
                    .HasName("id_cli")
                    .IsUnique();

                entity.Property(e => e.IdCli).HasColumnName("id_cli");

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(50);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(9);

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fecha_alta")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.Poblacion)
                    .HasColumnName("poblacion")
                    .HasMaxLength(50);

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Concesionario>(entity =>
            {
                entity.HasKey(e => e.IdConce)
                    .HasName("PRIMARY");

                entity.ToTable("concesionario");

                entity.Property(e => e.IdConce).HasColumnName("id_conce");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.IdEmple)
                    .HasName("PRIMARY");

                entity.ToTable("empleados");

                entity.HasIndex(e => e.Dni)
                    .HasName("DNI")
                    .IsUnique();

                entity.HasIndex(e => e.IdEmple)
                    .HasName("id_emple")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser)
                    .HasName("id_user");

                entity.Property(e => e.IdEmple).HasColumnName("id_emple");

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(50);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(9);

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fecha_alta")
                    .HasColumnType("date");

                entity.Property(e => e.IdJefe).HasColumnName("id_jefe");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.Poblacion)
                    .HasColumnName("poblacion")
                    .HasMaxLength(50);

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(50);

                entity.Property(e => e.Rango)
                    .HasColumnName("rango")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("empleados_ibfk_1");
            });

            modelBuilder.Entity<Piezas>(entity =>
            {
                entity.HasKey(e => e.IdPieza)
                    .HasName("PRIMARY");

                entity.ToTable("piezas");

                entity.HasIndex(e => e.IdPieza)
                    .HasName("id_pieza")
                    .IsUnique();

                entity.Property(e => e.IdPieza).HasColumnName("id_pieza");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100);

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fecha_alta")
                    .HasColumnType("date");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<Piezasrep>(entity =>
            {
                entity.HasKey(e => e.IdRep)
                    .HasName("PRIMARY");

                entity.ToTable("piezasrep");

                entity.HasIndex(e => e.IdPieza)
                    .HasName("id_pieza");

                entity.Property(e => e.IdRep).HasColumnName("id_rep");

                entity.Property(e => e.IdPieza).HasColumnName("id_pieza");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdPiezaNavigation)
                    .WithMany(p => p.Piezasrep)
                    .HasForeignKey(d => d.IdPieza)
                    .HasConstraintName("piezasrep_ibfk_1");

                entity.HasOne(d => d.IdRepNavigation)
                    .WithOne(p => p.Piezasrep)
                    .HasForeignKey<Piezasrep>(d => d.IdRep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("piezasrep_ibfk_2");
            });

            modelBuilder.Entity<Ppto>(entity =>
            {
                entity.HasKey(e => e.IdPresupuesto)
                    .HasName("PRIMARY");

                entity.ToTable("ppto");

                entity.HasIndex(e => e.IdCli)
                    .HasName("id_cli");

                entity.HasIndex(e => e.IdEmple)
                    .HasName("id_emple");

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("id_vehiculo");

                entity.Property(e => e.IdPresupuesto).HasColumnName("id_presupuesto");

                entity.Property(e => e.FechaPpto)
                    .HasColumnName("fecha_ppto")
                    .HasColumnType("date");

                entity.Property(e => e.FechaValidez)
                    .HasColumnName("fecha_validez")
                    .HasColumnType("date");

                entity.Property(e => e.IdCli).HasColumnName("id_cli");

                entity.Property(e => e.IdEmple).HasColumnName("id_emple");

                entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdCliNavigation)
                    .WithMany(p => p.Ppto)
                    .HasForeignKey(d => d.IdCli)
                    .HasConstraintName("ppto_ibfk_1");

                entity.HasOne(d => d.IdEmpleNavigation)
                    .WithMany(p => p.Ppto)
                    .HasForeignKey(d => d.IdEmple)
                    .HasConstraintName("ppto_ibfk_2");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Ppto)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("ppto_ibfk_3");
            });

            modelBuilder.Entity<Repara>(entity =>
            {
                entity.HasKey(e => e.IdRep)
                    .HasName("PRIMARY");

                entity.ToTable("repara");

                entity.HasIndex(e => e.IdCli)
                    .HasName("id_cli");

                entity.HasIndex(e => e.IdMec)
                    .HasName("id_mec");

                entity.HasIndex(e => e.IdRep)
                    .HasName("id_rep")
                    .IsUnique();

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("id_vehiculo");

                entity.Property(e => e.IdRep).HasColumnName("id_rep");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200);

                entity.Property(e => e.FechaFn)
                    .HasColumnName("fecha_fn")
                    .HasColumnType("date");

                entity.Property(e => e.FechaIni)
                    .HasColumnName("fecha_ini")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRepara)
                    .HasColumnName("fecha_repara")
                    .HasColumnType("date");

                entity.Property(e => e.HoraFn)
                    .HasColumnName("hora_fn")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.HoraIni)
                    .HasColumnName("hora_ini")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.IdCli).HasColumnName("id_cli");

                entity.Property(e => e.IdJefeTaller).HasColumnName("id_jefe_taller");

                entity.Property(e => e.IdMec).HasColumnName("id_mec");

                entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");

                entity.Property(e => e.PresuEsrti).HasColumnName("presu_esrti");

                entity.Property(e => e.Tiempo).HasColumnName("tiempo");

                entity.HasOne(d => d.IdCliNavigation)
                    .WithMany(p => p.Repara)
                    .HasForeignKey(d => d.IdCli)
                    .HasConstraintName("repara_ibfk_1");

                entity.HasOne(d => d.IdMecNavigation)
                    .WithMany(p => p.Repara)
                    .HasForeignKey(d => d.IdMec)
                    .HasConstraintName("repara_ibfk_2");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Repara)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("repara_ibfk_3");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Dni)
                    .HasName("DNI")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser)
                    .HasName("id_user")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(9);

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fecha_alta")
                    .HasColumnType("date");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasMaxLength(255);

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasColumnName("passwd")
                    .HasMaxLength(64);

                entity.Property(e => e.Rango)
                    .HasColumnName("rango")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Vehiculos>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PRIMARY");

                entity.ToTable("vehiculos");

                entity.HasIndex(e => e.Bastidor)
                    .HasName("bastidor")
                    .IsUnique();

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente");

                entity.HasIndex(e => e.IdConce)
                    .HasName("id_conce");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("id_usuario");

                entity.HasIndex(e => e.Matricula)
                    .HasName("matricula")
                    .IsUnique();

                entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.Bastidor)
                    .IsRequired()
                    .HasColumnName("bastidor")
                    .HasMaxLength(50);

                entity.Property(e => e.Combustible)
                    .HasColumnName("combustible")
                    .HasMaxLength(10);

                entity.Property(e => e.FechaAlta)
                    .HasColumnName("fecha_alta")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdConce).HasColumnName("id_conce");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Kilometros).HasColumnName("kilometros");

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasMaxLength(50);

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasColumnName("matricula")
                    .HasMaxLength(20);

                entity.Property(e => e.Modelo)
                    .HasColumnName("modelo")
                    .HasMaxLength(20);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("vehiculos_ibfk_1");

                entity.HasOne(d => d.IdConceNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdConce)
                    .HasConstraintName("vehiculos_ibfk_3");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("vehiculos_ibfk_2");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.IdVentas)
                    .HasName("PRIMARY");

                entity.ToTable("ventas");

                entity.HasIndex(e => e.IdCli)
                    .HasName("id_cli");

                entity.HasIndex(e => e.IdEmple)
                    .HasName("id_emple");

                entity.HasIndex(e => e.IdVehiculo)
                    .HasName("id_vehiculo");

                entity.HasIndex(e => e.IdVentas)
                    .HasName("id_ventas")
                    .IsUnique();

                entity.Property(e => e.IdVentas).HasColumnName("id_ventas");

                entity.Property(e => e.FechaPpto)
                    .HasColumnName("fecha_ppto")
                    .HasColumnType("date");

                entity.Property(e => e.FechaValidez)
                    .HasColumnName("fecha_validez")
                    .HasColumnType("date");

                entity.Property(e => e.IdCli).HasColumnName("id_cli");

                entity.Property(e => e.IdEmple).HasColumnName("id_emple");

                entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdCliNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdCli)
                    .HasConstraintName("ventas_ibfk_1");

                entity.HasOne(d => d.IdEmpleNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdEmple)
                    .HasConstraintName("ventas_ibfk_2");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("ventas_ibfk_3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
