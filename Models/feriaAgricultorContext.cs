using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace feria.Models
{
    public partial class feriaAgricultorContext : DbContext
    {
        public feriaAgricultorContext()
        {
        }

        public feriaAgricultorContext(DbContextOptions<feriaAgricultorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agricultor> Agricultors { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Puesto> Puestos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Agricultor>(entity =>
            {
                entity.HasKey(e => e.IdAgricultor);

                entity.ToTable("agricultor");

                entity.Property(e => e.IdAgricultor)
                    .ValueGeneratedNever()
                    .HasColumnName("id_agricultor");

                entity.Property(e => e.Apel1)
                    .HasMaxLength(50)
                    .HasColumnName("apel1");

                entity.Property(e => e.Apel2)
                    .HasMaxLength(50)
                    .HasColumnName("apel2");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria)
                    .ValueGeneratedNever()
                    .HasColumnName("id_categoria");

                entity.Property(e => e.Nonbre)
                    .HasMaxLength(50)
                    .HasColumnName("nonbre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_producto");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Unidades).HasColumnName("unidades");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_producto_categoria");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto);

                entity.ToTable("puesto");

                entity.Property(e => e.IdPuesto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_puesto");

                entity.Property(e => e.Disponibilidad).HasColumnName("disponibilidad");

                entity.Property(e => e.IdAgricultor).HasColumnName("id_agricultor");

                entity.Property(e => e.IdProducto1).HasColumnName("id_producto1");

                entity.Property(e => e.IdProducto2).HasColumnName("id_producto2");

                entity.Property(e => e.IdProducto3).HasColumnName("id_producto3");

                entity.Property(e => e.IdProducto4).HasColumnName("id_producto4");

                entity.Property(e => e.IdProducto5).HasColumnName("id_producto5");

                entity.HasOne(d => d.IdAgricultorNavigation)
                    .WithMany(p => p.Puestos)
                    .HasForeignKey(d => d.IdAgricultor)
                    .HasConstraintName("FK_puesto_agricultor");

                entity.HasOne(d => d.IdProducto1Navigation)
                    .WithMany(p => p.PuestoIdProducto1Navigations)
                    .HasForeignKey(d => d.IdProducto1)
                    .HasConstraintName("FK_puesto_producto1");

                entity.HasOne(d => d.IdProducto2Navigation)
                    .WithMany(p => p.PuestoIdProducto2Navigations)
                    .HasForeignKey(d => d.IdProducto2)
                    .HasConstraintName("FK_puesto_producto2");

                entity.HasOne(d => d.IdProducto3Navigation)
                    .WithMany(p => p.PuestoIdProducto3Navigations)
                    .HasForeignKey(d => d.IdProducto3)
                    .HasConstraintName("FK_puesto_producto");

                entity.HasOne(d => d.IdProducto4Navigation)
                    .WithMany(p => p.PuestoIdProducto4Navigations)
                    .HasForeignKey(d => d.IdProducto4)
                    .HasConstraintName("FK_puesto_producto4");

                entity.HasOne(d => d.IdProducto5Navigation)
                    .WithMany(p => p.PuestoIdProducto5Navigations)
                    .HasForeignKey(d => d.IdProducto5)
                    .HasConstraintName("FK_puesto_producto5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
