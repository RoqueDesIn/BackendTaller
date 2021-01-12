using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Repara
    {
        public int IdRep { get; set; }
        public int? IdCli { get; set; }
        public int? IdJefeTaller { get; set; }
        public int? IdMec { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaRepara { get; set; }
        public float? Tiempo { get; set; }
        public int? IdVehiculo { get; set; }
        public float? PresuEsrti { get; set; }
        public DateTime? FechaIni { get; set; }
        public DateTime? FechaFn { get; set; }
        public string HoraIni { get; set; }
        public string HoraFn { get; set; }

        public virtual Clientes IdCliNavigation { get; set; }
        public virtual Empleados IdMecNavigation { get; set; }
        public virtual Vehiculos IdVehiculoNavigation { get; set; }
        public virtual Piezasrep Piezasrep { get; set; }
    }
}
