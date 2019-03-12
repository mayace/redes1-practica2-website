using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace redes1_practica2
{
    public class VehiculosDB : DbContext
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public VehiculosDB(DbContextOptions<VehiculosDB> options) : base(options)
        {

        }
    }

    public class Vehiculo
    {
        [Key]
        public int IDVehiculo { get; set; }
        public string Nombre { get; set; }
    }
}
