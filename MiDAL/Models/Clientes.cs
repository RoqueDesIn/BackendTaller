using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Ppto = new HashSet<Ppto>();
            Repara = new HashSet<Repara>();
            Vehiculos = new HashSet<Vehiculos>();
            Ventas = new HashSet<Ventas>();
        }

        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Poblacion { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int IdCli { get; set; }

        public virtual ICollection<Ppto> Ppto { get; set; }
        public virtual ICollection<Repara> Repara { get; set; }
        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
