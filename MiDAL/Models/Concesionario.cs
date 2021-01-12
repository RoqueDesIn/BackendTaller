using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Concesionario
    {
        public Concesionario()
        {
            Vehiculos = new HashSet<Vehiculos>();
        }

        public int IdConce { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
