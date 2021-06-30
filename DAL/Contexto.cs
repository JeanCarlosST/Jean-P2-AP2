using Jean_P2_AP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jean_P2_AP2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Cobros> Cobros { get; set; }

        //public Contexto() { }

        //public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=CobrosDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clientes>().HasData(new Clientes() { ClienteID = 1, Nombres = "FERRETERIA GAMA" });
            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaID = 1, Fecha = new DateTime(2020, 09, 01), ClienteID = 1, Monto = 1000, Balance = 1000 });
            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaID = 2, Fecha = new DateTime(2020, 10, 01), ClienteID = 1, Monto = 900, Balance = 800 });
            modelBuilder.Entity<Clientes>().HasData(new Clientes() { ClienteID = 2, Nombres = "AVALON DISCO" });
            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaID = 3, Fecha = new DateTime(2020, 09, 01), ClienteID = 2, Monto = 2000, Balance = 2000 });
            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaID = 4, Fecha = new DateTime(2020, 10, 01), ClienteID = 2, Monto = 1900, Balance = 1800 });
            modelBuilder.Entity<Clientes>().HasData(new Clientes() { ClienteID = 3, Nombres = "PRESTAMOS CEFIPROD" });
            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaID = 5, Fecha = new DateTime(2020, 09, 01), ClienteID = 3, Monto = 3000, Balance = 3000 });
            modelBuilder.Entity<Ventas>().HasData(new Ventas() { VentaID = 6, Fecha = new DateTime(2020, 10, 01), ClienteID = 3, Monto = 2900, Balance = 1900 });

        }
    }
}
