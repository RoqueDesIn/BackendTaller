using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Empleados = new HashSet<Empleados>();
            Vehiculos = new HashSet<Vehiculos>();
        }

        public string Dni { get; set; }
        public string Nick { get; set; }
        public string Passwd { get; set; }
        public string Rango { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Foto { get; set; }
        public int IdUser { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
