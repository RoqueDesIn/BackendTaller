using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Ventas
    {
        public int IdVentas { get; set; }
        public int? IdCli { get; set; }
        public int? IdEmple { get; set; }
        public DateTime? FechaPpto { get; set; }
        public DateTime? FechaValidez { get; set; }
        public int? IdVehiculo { get; set; }
        public float? Precio { get; set; }

        public virtual Clientes IdCliNavigation { get; set; }
        public virtual Empleados IdEmpleNavigation { get; set; }
        public virtual Vehiculos IdVehiculoNavigation { get; set; }
    }
}
