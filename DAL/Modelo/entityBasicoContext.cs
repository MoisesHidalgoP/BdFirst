using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Modelo
{
    public partial class entityBasicoContext : DbContext
    {
        public entityBasicoContext()
        {
        }

        public entityBasicoContext(DbContextOptions<entityBasicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleado { get; set; } = null!;
        public virtual DbSet<NivelAcceso> NivelAccesos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleados");

                entity.Property(e => e.NombreEmpleado).HasColumnName("nombre_empleado");

                entity.HasMany(d => d.NivelAccesos)
                    .WithMany(p => p.Empleados)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmpleadonivelAcc",
                        l => l.HasOne<NivelAcceso>().WithMany().HasForeignKey("NivelAccesosId"),
                        r => r.HasOne<Empleado>().WithMany().HasForeignKey("EmpleadosId"),
                        j =>
                        {
                            j.HasKey("EmpleadosId", "NivelAccesosId");

                            j.ToTable("empleadonivel_acc");

                            j.HasIndex(new[] { "NivelAccesosId" }, "IX_empleadonivel_acc_nivel_accesosId");

                            j.IndexerProperty<int>("EmpleadosId").HasColumnName("empleadosId");

                            j.IndexerProperty<int>("NivelAccesosId").HasColumnName("nivel_accesosId");
                        });
            });

            modelBuilder.Entity<NivelAcceso>(entity =>
            {
                entity.ToTable("nivel_accesos");

                entity.Property(e => e.DescAcceso).HasColumnName("desc_acceso");

                entity.Property(e => e.NivelAcceso1).HasColumnName("nivel_acceso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
