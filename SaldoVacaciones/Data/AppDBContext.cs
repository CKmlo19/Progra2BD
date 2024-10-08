﻿using Microsoft.EntityFrameworkCore;
using SaldoVacaciones.Models;

//Para hacer las configuraciones de las tablas

namespace SaldoVacaciones.Data
{
    public class AppDBContext : DbContext
    {
        //conexion a la base de datos
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        //sobre escritura de nuestra tabla, para definir las caracteristicas de la tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(tabla =>
            {
                tabla.HasKey(col => col.Id);
                tabla.Property(col => col.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tabla.Property(col => col.Nombre).HasMaxLength(50);
                tabla.Property(e => e.SaldoVacaciones).HasColumnType("smallint");
            });

            //se convierte en una tabla de nombre Empleado
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
        }
    }
}