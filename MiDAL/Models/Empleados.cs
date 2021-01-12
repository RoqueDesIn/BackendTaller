using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Empleados
    {
        public Empleados()
        {
            Ppto = new HashSet<Ppto>();
            Repara = new HashSet<Repara>();
            Ventas = new HashSet<Ventas>();
        }

        public int IdEmple { get; set; }
        public string Rango { get; set; }
        public int? IdUser { get; set; }
        public int? IdJefe { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Poblacion { get; set; }

        public virtual Usuarios IdUserNavigation { get; set; }
        public virtual ICollection<Ppto> Ppto { get; set; }
        public virtual ICollection<Repara> Repara { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
